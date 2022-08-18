using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tesco.Model;

namespace Tesco.Service
{
    public class InventoryService : IInventoryService
    {
        #region LOCAL VARIABLES & WORKFLOW SESSION]
        private BasePath _basePathDirectory { get; set; }
        #endregion
        public InventoryService(BasePath basePathDirectory)
        {
            _basePathDirectory = basePathDirectory;
        }

        /// <summary>
        /// Fetches Products
        /// </summary>
        /// <returns>List of Products</returns>
        public List<Product> GetProducts() =>
            JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(_basePathDirectory.BaseDirectory + "\\Stock/Stock.json"));

        /// <summary>
        /// Fetches Products in Cart
        /// </summary>
        /// <returns>List of Products in Cart</returns>
        public List<CartItem> GetCartProducts() =>
            JsonConvert.DeserializeObject<List<CartItem>>(File.ReadAllText(_basePathDirectory.BaseDirectory + "\\Stock/Cart.json"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skuId"></param>
        /// <returns>CartItem</returns>
        public CartItem GetCartItem(int skuId)
        {
            List<CartItem> items = GetCartProducts();
            return items.Where(item => item.SkuId == skuId).First();
        }

        /// <summary>
        /// Adds product to cart
        /// </summary>
        /// <param name="skuId"></param>
        /// <returns>List of Product</returns> 
        /// <summary>
        public List<CartItem> AddtoCart(int skuId)
        {
            List<CartItem> cartItems = GetCartProducts();

            if (cartItems != null && cartItems.Any())
            {
                bool itemFound = false;
                for (int i = 0; i <= cartItems.Count(); i++)
                {
                    if (cartItems[i].SkuId == skuId)
                    {
                        itemFound = true;
                        cartItems[i].Quantity = cartItems[i].Quantity + 1;
                    }
                }

                if (itemFound == false)
                {
                    cartItems.Add(new CartItem { SkuId = skuId, Quantity = 1 });
                }
            }
            else
            {
                cartItems = new List<CartItem>
                {
                    new CartItem
                    {
                        SkuId = skuId,
                        Quantity = 1
                    }
                };
            }

            string json = JsonConvert.SerializeObject(cartItems);
            File.WriteAllText(_basePathDirectory.BaseDirectory + "\\Stock/Cart.json", json);
            List<CartItem> productList = GetCartProducts();
            return productList;
        }
    }
}
