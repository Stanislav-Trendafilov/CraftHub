using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CraftHub.Infrastructure.DataConstants;

namespace CraftHub.Infrastructure.Data.Models
{
	[Comment("This entity contains all the information about categories of the products")]
	public class ProductCategory
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(ProductCategoryNameMaxLength)]
		[Comment("String for name of the category")]
		public string Name { get; set; } = string.Empty;

		[Comment("Collection of all products that belong to this category")]
		public IEnumerable<Product> Products { get; set; } = new List<Product>();
	}
}
