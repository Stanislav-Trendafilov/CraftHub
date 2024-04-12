using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Core.Models.Product
{
	public class ProductQueryServiceModel
	{
		public int TotalProductsCount { get; set; }

		public IEnumerable<ProductServiceModel> Products { get; set; } = new List<ProductServiceModel>();
	}
}
