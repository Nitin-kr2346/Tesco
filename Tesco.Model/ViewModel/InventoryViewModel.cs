using System.Collections.Generic;

namespace Tesco.Model.ViewModel
{
    public class InventoryViewModel
    {
        virtual public List<Product> Products { get; set; }
        virtual public List<CartItem> CartItems { get; set; }
        virtual public bool? EnableAdd { get; set; }
        virtual public bool? AddtoCartClick { get; set; }
        virtual public int? SelectedProduct { get; set; }
    }
}
