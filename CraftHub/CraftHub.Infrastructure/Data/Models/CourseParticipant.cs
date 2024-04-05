using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CraftHub.Infrastructure.Data.Models
{
	[Comment("This is entity which makes possible many to many relation between classes.")]
	public class CourseParticipant
	{
		[Comment("Identifier of current course.")]
		[Required]
		public int CourseId { get; set; }

		[ForeignKey(nameof(CourseId))]
		public Course Course { get; set; } = null!;

		[Comment("Identifier of the participant who will go on the course.")]
		[Required]
		public string ParticipantId { get; set; } = string.Empty;

		[ForeignKey(nameof(ParticipantId))]
		public IdentityUser Participant { get; set; } = null!;
	}
}