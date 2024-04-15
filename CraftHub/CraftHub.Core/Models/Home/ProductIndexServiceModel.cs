using CraftHub.Core.Contracts;

namespace CraftHub.Core.Models.Home
{
    public class ProductIndexServiceModel:IProductModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
	}
}
