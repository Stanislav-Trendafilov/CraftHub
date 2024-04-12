using CraftHub.Core.Enumerations;
using CraftHub.Core.Models.Home;
using CraftHub.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Core.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductIndexServiceModel>> MostLikedProductsAsync();

		Task<IEnumerable<ProductCategoryServiceModel>> AllProductCategoriesAsync();

		Task<bool> CategoryExistsAsync(int categoryId);

		Task<int> CreateAsync(AddProductFormModel model, int creatorId);

		Task<ProductQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, ProductSorting sorting=ProductSorting.Newest, int currentPage = 1, int housesPerPage = 1);

		Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<bool> ExistsAsync(int id);

        Task<ProductDetailsServiceModel> HouseDetailsByIdAsync(int id);

    }
}
