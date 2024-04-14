using System.ComponentModel.DataAnnotations;
using static CraftHub.Core.Constants.MessageConstants;
using static CraftHub.Infrastructure.DataConstants;


namespace CraftHub.Core.Models.Creator
{
	public class BecomeCreatorFormModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(CreatorPhoneNumberMaxLength, MinimumLength = CreatorPhoneNumberMinLength, ErrorMessage = LengthMessage)]
		[Display(Name = "Phone number")]
		[Phone]
		public string PhoneNumber { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(CreatorFullNameMaxLength, MinimumLength = CreatorFullNameMinLength, ErrorMessage = LengthMessage)]
		public string FullName { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(CreatorsBusinessNameMaxLength, MinimumLength = CreatorsBusinessNameMinLength, ErrorMessage = LengthMessage)]
		public string BusinessName { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(CreatorsMoreInformationMaxLength, MinimumLength = 0, ErrorMessage = LengthMessage)]
		public string MoreInformation { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		public string Email { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		public string Website { get; set; } = null!;

	}
}
