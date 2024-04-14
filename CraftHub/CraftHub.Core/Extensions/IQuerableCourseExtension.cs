using CraftHub.Core.Models.Course;
using CraftHub.Infrastructure.Data.Models;

namespace CraftHub.Core.Extensions
{
    public static class IQuerableCourseExtension
    {
        public static IQueryable<CourseServiceModel> ProjectToCourseServiceModel(this IQueryable<Course> courses)
        {
            return courses.Select(p => new CourseServiceModel()
            {
                Id = p.Id,
                Title = p.Title,
                Details = p.Details,
                Location = p.Location,
                Duration = p.Duration ,
                Lecturer= p.Lecturer
               
            });
        }
    }
}
