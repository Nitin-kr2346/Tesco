namespace Tesco.Helper
{
    public partial class Constants
    {
        public const string DEF = "default";
        public const string API = "API";
        public const string INTERFACE = "Interface";
        public const string IMPLEMENTATION = "Implementation";
        public const string ERRORREDIRECT = "/Home/Error";
        public const string LOGINPATTERN = "{controller=Login}/{action=Index}/{id?}";
        public const string TESCOPATTERN = "{controller=Tesco}/{action=Inventory}/{id?}";
        public const string APPLICATIONJSON = "application/json";

        public const string GETPRODUCTS = "Inventory/GetProducts";
        public const string ADDTOCART = "Inventory/AddtoCart";
        public const string GETPRODUCTSINCART = "Inventory/GetProductsInCart";

        public const string TESCO = "Tesco";
        public const string INVENTORY = "Inventory";
        public const string CHECKOUT = "Checkout";

        public const string CARTDETAILS = "_CartDetails";
    }
}
