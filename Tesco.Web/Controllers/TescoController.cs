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
    }
}
