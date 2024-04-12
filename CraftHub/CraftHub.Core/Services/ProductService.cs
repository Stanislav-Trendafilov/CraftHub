using CraftHub.Core.Contracts;
using CraftHub.Core.Enumerations;
using CraftHub.Core.Extensions;
using CraftHub.Core.Models.Home;
using CraftHub.Core.Models.Product;
using CraftHub.Infrastructure.Data.Common;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftHub.Core.Services
{
    public class ProductService :IProductService
    {
        private readonly IRepository repository;

        public ProductService(IRepository _repository)
        {
            repository = _repository;
        }
	
		public async Task<ProductQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, ProductSorting sorting = ProductSorting.Newest, int currentPage = 1, int productsPerPage = 1)
		{
			var productsToShow = repository.AllReadOnly<Product>();

			if (category != null)
			{
				productsToShow = productsToShow
					 .Where(p => p.ProductCategory.Name == category);
			}

			if (searchTerm != null)
			{
				string normalizedSearchTerm = searchTerm.ToLower();

				productsToShow = productsToShow
					.Where(p => (p.Title.ToLower().Contains(normalizedSearchTerm) ||
								p.Description.ToLower().Contains(normalizedSearchTerm)));
			}
			productsToShow = sorting switch
			{
				ProductSorting.PriceLowestFirst => productsToShow
					.OrderBy(p => p.Price),
				ProductSorting.PriceHigherFirst => productsToShow
					.OrderByDescending(p => p.Price)
					.ThenByDescending(p => p.Id),
				_ => productsToShow
					.OrderByDescending(p => p.Id)
			};

			var products = await productsToShow
				.Skip((currentPage - 1) * productsPerPage)
				.Take(productsPerPage)
				.ProjectToProductServiceModel()
				.ToListAsync();

			int totalProducts = await productsToShow.CountAsync();

			return new ProductQueryServiceModel()
			{
				Products = products,
				TotalProductsCount = totalProducts
			};
		}
		public async Task<IEnumerable<ProductIndexServiceModel>> MostLikedProductsAsync()
        {
            return await repository
              .AllReadOnly<Product>()
              .OrderByDescending(p => p.Id)
              .Select(p => new ProductIndexServiceModel()
              {
                  Id = p.Id,
                  ImageUrl = p.ImageUrl,
                  Title = p.Title

              }).ToListAsync();
        }

		public async Task<int> CreateAsync(AddProductFormModel model, int creatorId)
		{
			Product product = new Product()
			{
                Title= model.Title,
                Description=model.Description,
                Price=model.Price,
                ImageUrl=model.ImageUrl,
                ProductCategoryId=model.CategoryId,
                CreatorId=creatorId
			};

			await repository.AddAsync(product);
			await repository.SaveChangesAsync();

			return product.Id;
		}

		public async Task<IEnumerable<ProductCategoryServiceModel>> AllProductCategoriesAsync()
		{
			return await repository.AllReadOnly<ProductCategory>()
				 .Select(c => new ProductCategoryServiceModel
				 {
					 Id = c.Id,
					 Name = c.Name,
				 })
				 .ToListAsync();
		}

		public async Task<bool> CategoryExistsAsync(int categoryId)
		{
			return await repository.AllReadOnly<ProductCategory>()
				   .AnyAsync(x => x.Id == categoryId);
		}

		public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
		{
			return await repository.AllReadOnly<ProductCategory>()
			  .Select(c => c.Name)
			  .Distinct()
			  .ToListAsync();
		}
	}
}
