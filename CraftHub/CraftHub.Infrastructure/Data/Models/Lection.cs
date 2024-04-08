using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CraftHub.Infrastructure.DataConstants;

namespace CraftHub.Infrastructure.Data.Models
{
	[Comment("Class which holds all information about the lection in the course.")]
	public class Lection
	{
		[Key]
		[Comment("This is the id, representing this lection.")]
		public int Id { get; set; }

		[Required]
		[Comment("This is te topic of the lection.")]
		[MaxLength(TopicMaxLength)]
		public string Topic { get; set; } = string.Empty;

		[Required]
		[Comment("More details about the lection.")]
		[MaxLength(DetailsMaxLength)]
		public string Details { get; set; } = string.Empty;

		[Comment("The date of the lection.")]
		public DateTime DateAndTime { get; set; }


		[Required]
		[Comment("Id of the course which contains this lection.")]
		public int CourseId { get; set; }

		[Required]
		[Comment("Course as entity model.")]
		[ForeignKey(nameof(CourseId))]
		public Course Course { get; set; } = null!;

	}
}