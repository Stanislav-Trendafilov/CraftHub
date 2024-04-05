using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using static CraftHub.Infrastructure.DataConstants;

namespace CraftHub.Infrastructure.Data.Models
{
	[Comment("Class which holds all information about the course.")]
	public class Course
	{
		[Key]
		[Comment("This is the id, representing this course.")]
		public int Id { get; set; }

		[Required]
		[Comment("This is string which contains the topic of the course.")]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = string.Empty;

		[Required]
		[Comment("This is the person who will lecture the course.")]
		[MaxLength(LecturerMaxLength)]
		public string Lecturer { get; set; } = string.Empty;

		[Required]
		[Comment("More details about the course.")]
		[MaxLength(DetailsMaxLength)]
		public string Details { get; set; } = string.Empty;


		[Required]
		[Comment("Id of the creator who is the creator.")]
		public string CreatorId { get; set; } = string.Empty;

		[Required]
		[Comment("Organizer of the event as a Creator.")]
		[ForeignKey(nameof(CreatorId))]
		public Creator Organizer { get; set; } = null!;


		[Required]
		[Comment("This string contains the location of the course.")]
		public string Location { get; set; } = string.Empty;

		[Required]
		[Comment("Id of the course category.")]
		public int CategoryId { get; set; }

		[Required]
		[Comment("Category of the course.")]
		[ForeignKey(nameof(CategoryId))]
		public CourseCategory Category { get; set; } = null!;

		[Required]
		[Comment("Duration of the course in months. How long it will take?")]
		[Range(DurationMinLength, DurationMaxLength)]
		public int Duration { get; set; }


		[Comment("All lections which contains the current course.")]
		public IEnumerable<Lection> Lections { get; set; } = new List<Lection>();


		[Comment("People who will join the course (participants).")]
		public IList<CourseParticipant> CourseParticipants { get; set; } = new List<CourseParticipant>();
	}
}