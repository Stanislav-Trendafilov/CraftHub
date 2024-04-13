using CraftHub.Core.Models.Creator;

namespace CraftHub.Core.Models.Product
{
    public class ProductDetailsServiceModel  :ProductServiceModel
    {
        public string Category { get; set; } = string.Empty;
        public CreatorServiceModel Creator { get; set; } = null!;
        public IEnumerable<string> AllCategories { get; set; }=new List<string>();
    }
}
