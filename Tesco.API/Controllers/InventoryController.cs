using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tesco.Model;
using Tesco.Service;

namespace Tesco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        protected IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// Fetches Products
        /// </summary>
        /// <returns>List of Products</returns>
        [HttpGet("GetProducts")]
        [ProducesResponseType(typeof(List<Product>), 200)]
        public ActionResult GetProducts()
        {
            List<Product> products = _inventoryService.GetProducts();
            if (products.Count > 0)
            {
                return Ok(products);
            }
            return BadRequest(products);
        }

        /// <summary>
        /// Fetches Products
        /// </summary>
        /// <returns>List of Products</returns>
        [HttpGet("GetProductsInCart")]
        [ProducesResponseType(typeof(CheckoutModel), 200)]
        public ActionResult GetProductsInCart()
        {
            CheckoutModel products = _inventoryService.GetProductsInCart();
            if (products.CartItems.Any() && products.Products.Any())
            {
                return Ok(products);
            }
            return BadRequest(products);
        }

        /// <summary>
        /// Add products to cart
        /// </summary>
        /// <returns>List of Cart Items</returns>
        [HttpPost("AddtoCart")]
        [ProducesResponseType(typeof(List<CartItem>), 200)]
        public ActionResult AddtoCart([FromBody]int skuId)
        {
            List<CartItem> cartItems = _inventoryService.AddtoCart(skuId);
            if (cartItems.Count > 0)
            {
                return Ok(cartItems);
            }
            return BadRequest(cartItems);
        }
    }
}
