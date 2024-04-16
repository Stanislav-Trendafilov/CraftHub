using CraftHub.Core.Models.Product;

namespace CraftHub.Core.Models.Cart
{
    public class ShopCartViewModel
    {
        public decimal TotalProductSum { get; set; }

        public decimal Delivery { get; set; }

        public decimal TotalSum { get; set; }

        public List<ProductServiceModel> products { get; set; }=new List<ProductServiceModel>();
    }
}
