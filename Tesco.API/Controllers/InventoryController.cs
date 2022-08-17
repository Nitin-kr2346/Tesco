using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    }
}
