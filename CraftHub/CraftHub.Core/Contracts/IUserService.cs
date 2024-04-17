using CraftHub.Core.Models.Admin.User;
using CraftHub.Core.Models.Product;

namespace CraftHub.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserServiceModel>> AllAsync();

        Task<int> CreateProductCategoryAsync(string productCategory);

        Task<bool> ProductCategoryExistsAsync(string productCategory);

        Task<int> CreateCourseCategoryAsync(string courseCategory);

        Task<bool> CourseCategoryExistsAsync(string courseCategory);
    }
}
