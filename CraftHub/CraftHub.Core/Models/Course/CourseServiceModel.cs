using System.ComponentModel.DataAnnotations;
using static CraftHub.Core.Constants.MessageConstants;
using static CraftHub.Infrastructure.DataConstants;

namespace CraftHub.Core.Models.Course
{
    public class CourseServiceModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DetailsMaxLength, MinimumLength = DetailsMinLength, ErrorMessage = LengthMessage)]
        public string Details { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public int Duration { get; set; }

    }
}
