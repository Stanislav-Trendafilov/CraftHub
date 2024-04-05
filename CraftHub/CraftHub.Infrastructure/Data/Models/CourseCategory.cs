using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CraftHub.Infrastructure.DataConstants;

namespace CraftHub.Infrastructure.Data.Models
{
	[Comment("This class contains information about category of the course.")]
	public class CourseCategory
	{
		[Key]
		[Comment("Identifier of the course category.")]
		public int Id { get; set; }

		[Required]
		[Comment("Name of the category.")]
		[MaxLength(ProductCategoryNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		[Comment("This collection holds all the courses which are in this category.")]
		public IList<Course> Courses { get; set; } = new List<Course>();
	}
}