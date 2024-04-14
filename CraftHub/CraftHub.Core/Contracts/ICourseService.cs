using CraftHub.Core.Models.Course;

namespace CraftHub.Core.Contracts
{
	public interface ICourseService
	{
		Task<int> CreateAsync(AddCourseFormModel model, int creatorId);

		Task<IEnumerable<CourseCategoryServiceModel>> AllCourseCategoriesAsync();

		Task<bool> CategoryExistsAsync(int categoryId);

        Task<AllCoursesModel> AllAsync(string? category = null);

        Task<bool> HasCreatorWithIdAsync(int productId, string userId);
    }
}
