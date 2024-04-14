using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Course;
using CraftHub.Core.Models.Product;
using CraftHub.Infrastructure.Data.Common;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Core.Services
{
	public class CourseService:ICourseService
	{
		private readonly IRepository repository;

		public CourseService(IRepository _repository)
		{
			repository = _repository;
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
	}
}
