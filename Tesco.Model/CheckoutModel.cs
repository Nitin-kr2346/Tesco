using System.Collections.Generic;

namespace Tesco.Model
{
    public class CheckoutModel
    {
        virtual public List<Product> Products { get; set; }
        virtual public List<CartItem> CartItems { get; set; }
    }
}
