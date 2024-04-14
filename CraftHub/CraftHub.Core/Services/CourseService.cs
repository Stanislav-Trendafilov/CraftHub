using CraftHub.Core.Contracts;
using CraftHub.Core.Extensions;
using CraftHub.Core.Models.Course;
using CraftHub.Core.Models.Creator;
using CraftHub.Core.Models.Product;
using CraftHub.Infrastructure.Data.Common;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftHub.Core.Services
{
	public class CourseService : ICourseService
	{
		private readonly IRepository repository;

		public CourseService(IRepository _repository)
		{
			repository = _repository;
		}

        public async Task<AllCoursesModel> AllAsync(string? category = null)
        {
            var coursesToShow = repository.AllReadOnly<Course>();

            if (category != null)
            {
                coursesToShow = coursesToShow.Where(p => p.CourseCategory.Name == category);
            }  

            int totalCourses = await coursesToShow.CountAsync();

            return new AllCoursesModel()
            {
                Courses = coursesToShow.ProjectToCourseServiceModel(),
                TotalCoursesCount = totalCourses
            };
        }

        public async Task<IEnumerable<CourseCategoryServiceModel>> AllCourseCategoriesAsync()
		{
			return await repository.AllReadOnly<CourseCategory>()
				 .Select(c => new CourseCategoryServiceModel
				 {
					 Id = c.Id,
					 Name = c.Name,
				 }).ToListAsync();
		}

		public async Task<bool> CategoryExistsAsync(int categoryId)
		{
			return await repository.AllReadOnly<CourseCategory>()
				   .AnyAsync(x => x.Id == categoryId);
		}


		public async Task<int> CreateAsync(AddCourseFormModel model, int creatorId)
		{
			Course course = new Course()
			{
				Title = model.Title,
				Details = model.Details,
				Duration = model.Duration,
				Location = model.Location,
				Lecturer = repository.
						AllReadOnly<Creator>()
						.Where(x => x.Id == creatorId)
						.FirstOrDefault().FullName,
				CourseCategoryId = model.CategoryId,
				CreatorId = creatorId
			};

			await repository.AddAsync(course);
			await repository.SaveChangesAsync();

			return course.Id;
		}

		//not used
        public async Task<bool> HasCreatorWithIdAsync(int productId, string userId)
        {
            return await repository.AllReadOnly<Course>()
                .AnyAsync(p => p.Id == productId && p.Organizer.UserId == userId);

        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Course>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<CourseDetailsModel> CourseDetailsByIdAsync(int id)
        {

            return await repository.AllReadOnly<Course>()
            .Where(p => p.Id == id)
            .Select(p => new CourseDetailsModel()
            {
                Id = p.Id,
                Title = p.Title,
                Category = p.CourseCategory.Name,
                Duration=p.Duration,
                Details = p.Details,
                Lecturer = p.Lecturer,
                Creator = new CreatorServiceModel()
                {
                    Email = p.Organizer.User.Email,
                    PhoneNumber = p.Organizer.PhoneNumber,
                    BusinessName = p.Organizer .BusinessName,
                    FullName = p.Organizer.FullName,
                    Website = p.Organizer.Website
                },
            }).FirstAsync();
        }

    }
}
