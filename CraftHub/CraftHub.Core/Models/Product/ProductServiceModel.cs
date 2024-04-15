using CraftHub.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static CraftHub.Core.Constants.MessageConstants;
using static CraftHub.Infrastructure.DataConstants;

namespace CraftHub.Core.Models.Product
{
	public class ProductServiceModel  :IProductModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(ProductTitleMaxLength, MinimumLength = ProductTitleMinLength, ErrorMessage = LengthMessage)]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength, ErrorMessage = LengthMessage)]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[Range(typeof(decimal), "0.0", "10000.00", ErrorMessage = "Price per month must be a positive number and less than {2} leva")]
		public decimal Price { get; set; }


		[Required(ErrorMessage = RequiredMessage)]
		public string ImageUrl { get; set; } = string.Empty;

	}
}
