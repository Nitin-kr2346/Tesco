using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Tesco.Helper;
using Tesco.Model;
using Tesco.Model.ViewModel;
using Tesco.Web.Helper;

namespace Tesco.Web.Controllers
{
    public class TescoController : Controller
    {
        #region LOCAL VARIABLES
        private API _apiUrl { get; set; }
        #endregion

        public TescoController(IOptions<API> apiUrl)
        {
            _apiUrl = apiUrl.Value;
        }

        /// <summary>
        /// Get Method for Tesco Controlller which loads Products
        /// </summary>
        /// <returns>Loads View</returns>
        [HttpGet]
        public async Task<IActionResult> Inventory()
        {
            InventoryViewModel model = new InventoryViewModel();
            HttpResponseMessage httpResponse = await APIHelper.GetHttpClient(_apiUrl).GetAsync(Constants.GETPRODUCTS);
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                model.Products = JsonConvert.DeserializeObject<List<Product>>(result);
            }
            return View(model);
        }

        /// <summary>
        /// Post Method for Inventory
        /// </summary>
        /// <returns>Loads View</returns>
        [HttpPost]
        public async Task<IActionResult> Inventory(InventoryViewModel model)
        {
            if (model.AddtoCartClick == true)
            {
                HttpResponseMessage httpResponse = await APIHelper.GetHttpClient(_apiUrl).PostAsJsonAsync(Constants.ADDTOCART, model.SelectedProduct);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    model.CartItems = JsonConvert.DeserializeObject<List<CartItem>>(result);
                    return PartialView(Constants.CARTDETAILS, model);
                }
            }
            return View(model);
        }

        /// <summary>
        /// Get Method for Tesco Controlller which loads Products in Cart
        /// </summary>
        /// <returns>Loads View</returns>
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            CheckoutModel model = new CheckoutModel();
            HttpResponseMessage httpResponse = await APIHelper.GetHttpClient(_apiUrl).GetAsync(Constants.GETPRODUCTSINCART);
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<CheckoutModel>(result);
            }

            if (model != null && model.CartItems.Any())
            {
                for (int i = 0; i < model.CartItems.Count; i++)
                {
                    var item = model.CartItems[i];
                    Product product = model.Products.Where(p => p.SkuId == item.SkuId).FirstOrDefault();
                    if (item.Quantity >= product.OfferQuantity && DateTime.Now <= product.OfferExpiryDate)
                    {
                        model.CartItems[i].Total = ((item.Quantity - (item.Quantity % product.OfferQuantity)) * product.OfferPrice) + ((item.Quantity % product.OfferQuantity) * product.Price);
                    }
                    else
                    {
                        model.CartItems[i].Total = item.Quantity * product.Price;
                    }
                }
            }

            return View(model);
        }
    }
}
