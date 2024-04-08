using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CraftHub.Infrastructure.DataConstants;

namespace CraftHub.Infrastructure.Data.Models
{
	[Comment("This is entity which contains all the information about the creator")]
	[Index(nameof(PhoneNumber), IsUnique = true)]
	public class Creator
	{
		[Key]
		[Comment("Special identifier for every creator")]
		public string Id { get; set; }

		[Required]
		[Comment("String for the creator's phone number.")]
		[MaxLength(CreatorPhoneNumberMaxLength)]
		public string PhoneNumber { get; set; } = string.Empty;

		[Required]
		[Comment("String for the creator's name.")]
		[MaxLength(CreatorFullNameMaxLength)]
		public string FullName { get; set; } = string.Empty;

		[Required]
		[Comment("String for the name of the business.")]
		[MaxLength(CreatorsBusinessNameMaxLength)]
		public string BusinessName { get; set; } = string.Empty;

		[Comment("String which contains more information about the creator's work")]
		[MaxLength(CreatorsMoreInformationMaxLength)]
		public string MoreInformation { get; set; } = string.Empty;

		[Required]
		[Comment("String for the user's email.")]
		public string Email { get; set; } = string.Empty;

		[Required]
		[Comment("String for the creator's website")]
		public string Website { get; set; } = string.Empty;


		[Required]
		public string? UserId { get; set; } = null!;

		[ForeignKey(nameof(UserId))]
		public IdentityUser User { get; set; } = null!;


		[Comment("This collection saves creator's products")]
		public IEnumerable<Product> Products { get; set; } = new List<Product>();

		[Comment("This collection saves courses that creator will lecture")]
		public IEnumerable<Course> Courses { get; set; } = new List<Course>();

	}
}
