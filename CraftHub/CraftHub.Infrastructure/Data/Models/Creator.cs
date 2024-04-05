using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CraftHub.Infrastructure.DataConstants;

namespace CraftHub.Infrastructure.Data.Models
{
	[Comment("This is entity which contains all the information about creator")]
	public class Creator
	{
		[Key]
		[Comment("Special identifier for every user")]
		public int Id { get; set; }

		[Required]
		[Comment("String for the user's phone number.")]
		[MaxLength(CreatorPhoneNumberMaxLength)]
		public string PhoneNumber { get; set; } = string.Empty;

		[Required]
		[Comment("String for the name of the business.")]
		[MaxLength(BusinessNameMaxLength)]
		public string BusinessName { get; set; } = string.Empty;

		[Required]
		[Comment("Strings for the creator's name.")]
		[MaxLength(FullNameMaxLength)]
		public string FullName { get; set; } = string.Empty;

		[Required]
		[Comment("String for the user's address.")]
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


		//not sure
		[Comment("This collection saves courses that creator will participate in")]
		public IEnumerable<Course> Courses { get; set; } = new List<Course>();

	}
}
