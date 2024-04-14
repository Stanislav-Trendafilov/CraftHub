namespace CraftHub.Core.Models.Course
{
    public class AllCoursesModel
    {
        public string Category { get; init; } = null!;

        public int TotalCoursesCount { get; set; }

        public IEnumerable<CourseServiceModel> Courses { get; set; } = new List<CourseServiceModel>();
    }
}
