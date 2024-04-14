using CraftHub.Core.Models.Product;
using CraftHub.Infrastructure.Data.Models;

namespace CraftHub.Core.Extensions
{
	public static class IQuerableProductExtension
	{
		public static IQueryable<ProductServiceModel> ProjectToProductServiceModel(this IQueryable<Product> products)
		{
			return products.Select(p => new ProductServiceModel()
			{
				 Id= p.Id,
				 Title=p.Title,
				 Description=p.Description,
				 ImageUrl=p.ImageUrl,
				 Price=p.Price	

			});
		}
	}
}
