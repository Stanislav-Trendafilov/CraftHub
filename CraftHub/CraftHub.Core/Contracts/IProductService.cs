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

		
	}
}
