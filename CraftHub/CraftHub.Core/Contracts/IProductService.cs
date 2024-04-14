using CraftHub.Core.Enumerations;
using CraftHub.Core.Models.Home;
using CraftHub.Core.Models.Product;

namespace CraftHub.Core.Contracts
{
	public interface IProductService
    {
        Task<IEnumerable<ProductIndexServiceModel>> MostLikedProductsAsync();

		Task<IEnumerable<ProductCategoryServiceModel>> AllProductCategoriesAsync();

		Task<bool> CategoryExistsAsync(int categoryId);

		Task<int> CreateAsync(AddProductFormModel model, int creatorId);

		Task<ProductQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, ProductSorting sorting=ProductSorting.Newest, int currentPage = 1, int productsPerPage = 1);

		Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<bool> ExistsAsync(int id);

        Task<ProductDetailsServiceModel> ProductDetailsByIdAsync(int id);

		Task<IEnumerable<ProductServiceModel>> AllProductsByCreatorIdAsync(int creatorId);

		Task EditAsync(int productId, AddProductFormModel model);

		Task<bool> HasCreatorWithIdAsync(int productId, string userId);

		Task<AddProductFormModel?> GetProductFormModelByIdAsync(int id);

		Task Delete(int productId);
	}
}
