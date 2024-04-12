using CraftHub.Core.Models.Product;
using CraftHub.Core.Services;
using CraftHub.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
