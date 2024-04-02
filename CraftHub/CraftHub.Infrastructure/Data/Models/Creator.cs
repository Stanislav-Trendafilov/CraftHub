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
		[Comment("String for the user's username.")]
		public string Username { get; set; } = string.Empty;

		[Required]
		[Comment("Strings for the user's names.")]
		public string FullName { get; set; } = string.Empty;


	}
	//	Username: String for the user's username.
	//Password: Hash of the password.
	//Email: String for the user's email address.
	//First Name and Last Name: Strings for the user's names.
	//Address: String for the user's address.
	//Phone Number: String for the user's phone number.
	//Registration Date: Date and time of the user's registration.
}
