using CraftHub.Core.Models.Creator;

namespace CraftHub.Core.Models.Course
{
    public class CourseDetailsModel  :CourseServiceModel
    {
        public string Category { get; set; } = string.Empty;
        public CreatorServiceModel Creator { get; set; } = null!;
    }
}
