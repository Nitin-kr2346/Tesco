using System.Collections.Generic;

namespace Tesco.Model.ViewModel
{
    public class InventoryViewModel
    {
        virtual public List<Product> Products { get; set; }
        virtual public bool? EnableAdd { get; set; }
        virtual public bool? SaveClick { get; set; }
        virtual public int? SelectedMedicine { get; set; }
    }
}
