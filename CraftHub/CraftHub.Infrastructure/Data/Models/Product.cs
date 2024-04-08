using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftHub.Infrastructure.DataConstants;

namespace CraftHub.Infrastructure.Data.Models
{
	[Comment("Entity which contains all the information about one product.")]
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Comment("String for the product's title.")]
		[MaxLength(ProductTitleMaxLength)]
		public string Title { get; set; } = string.Empty;

		[Required]
		[Comment("Text for the product's description.")]
		[MaxLength(ProductDescriptionMaxLength)]
		public string Description { get; set; } = string.Empty;

		[Required]
		[Comment("Price of the product(floating-point number).")]
		[Range(ProductPriceMinimum,ProductPriceMaximum)]
		public decimal Price { get; set; }

		[Required]
		[Comment("ImageURl for the image of the product.")]
		public string ImageUrl { get; set; } = string.Empty;

		[Required]
		[Comment("Identifier which saves the id of the category.")]
		public int ProductCategoryId { get; set; }

		[ForeignKey(nameof(ProductCategoryId))]
		public ProductCategory ProductCategory { get; set; } = null!;

		[Required]
		[Comment("Identifier which saves the id of the creator.")]
		public int CreatorId { get; set; } 

		[ForeignKey(nameof(CreatorId))]
		public Creator Creator { get; set; } = null!;

	}
}
