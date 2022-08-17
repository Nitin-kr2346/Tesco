using System.Collections.Generic;
using Tesco.Model;

namespace Tesco.Service
{
    public interface IInventoryService
    {
        public List<Product> GetProducts();
    }
}
