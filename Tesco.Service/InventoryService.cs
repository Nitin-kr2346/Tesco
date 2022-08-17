using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
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
    }
}
