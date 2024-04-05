using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CraftHub.Infrastructure.Data.Models
{
	public class Creator
	{
		[Key]
		[Comment("Special identifier for every user")]
		public int Id { get; set; }

		[Required]
		[Comment("String for the user's phone number.")]
		public string PhoneNumber { get; set; } = string.Empty;

		[Required]
		[Comment("String for the name of the business.")]
		public string Username { get; set; } = string.Empty;

		[Required]
		[Comment("Strings for the creator's name.")]
		public string FullName { get; set; } = string.Empty;

		[Required]
		[Comment("String for the user's address.")]
		public string Email { get; set; } = string.Empty;

		[Required]
		[Comment("String for the creator's website")]
		public string Website { get; set; } = string.Empty;

		[Comment("This collection saves creator's products")]
		public IEnumerable<Product> Products { get; set; }=new List<Product>();

		[Comment("This collection saves all the ")]
		public IEnumerable<Course> Seminars { get; set; } = new List<Course>();

	}
}
