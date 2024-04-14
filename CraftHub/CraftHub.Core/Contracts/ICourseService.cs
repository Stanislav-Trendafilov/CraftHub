using CraftHub.Core.Models.Course;
using CraftHub.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Core.Contracts
{
	public interface ICourseService
	{
		Task<int> CreateAsync(AddCourseFormModel model, int creatorId);

		Task<IEnumerable<CourseCategoryServiceModel>> AllCourseCategoriesAsync();

		Task<bool> CategoryExistsAsync(int categoryId);
	}
}
