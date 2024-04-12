namespace CraftHub.Core.Models.Product
{
	public class ProductQueryServiceModel
	{
		public int TotalProductsCount { get; set; }

		public IEnumerable<ProductServiceModel> Products { get; set; } = new List<ProductServiceModel>();
	}
}
