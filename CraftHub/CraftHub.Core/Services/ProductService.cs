using CraftHub.Core.Contracts;
using CraftHub.Core.Enumerations;
using CraftHub.Core.Extensions;
using CraftHub.Core.Models.Creator;
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

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Product>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<ProductDetailsServiceModel> ProductDetailsByIdAsync(int id)
        {	var allCategories=await repository.AllReadOnly<ProductCategory>()
              .Select(c => c.Name)
              .Distinct()
              .ToListAsync();
				return await repository.AllReadOnly<Product>()
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsServiceModel()
                {
                    Id = p.Id,
					Title=p.Title,
                    Category = p.ProductCategory.Name,
                    Description = p.Description,
					Price= p.Price,
                    ImageUrl = p.ImageUrl,
                    Creator = new CreatorServiceModel()
                    {
                        Email = p.Creator.User.Email,
                        PhoneNumber = p.Creator.PhoneNumber	 ,
						BusinessName= p.Creator.BusinessName,
						FullName= p.Creator.FullName,
						Website= p.Creator.Website
                    },
                    AllCategories=allCategories


                }).FirstAsync();
        }

		public async Task<IEnumerable<ProductServiceModel>> AllProductsByCreatorIdAsync(int creatorId)
		{
			return await repository.AllReadOnly<Product>()
				  .Where(p => p.CreatorId == creatorId)
				  .ProjectToProductServiceModel()
				  .ToListAsync();
		}

		public async Task EditAsync(int productId, AddProductFormModel model)
		{
			var product = await repository.GetByIdAsync<Product>(productId);

			if (product != null)
			{
				product.Title = model.Title;
                product.Description = model.Description;
				product.Price = model.Price;
				product.ImageUrl = model.ImageUrl;
				product.ProductCategoryId = model.CategoryId;

				await repository.SaveChangesAsync();
			}
		}

		public async Task<AddProductFormModel?> GetProductFormModelByIdAsync(int id)
		{
			var product = await repository.AllReadOnly<Product>()
				.Where(p => p.Id == id)
				.Select(p => new AddProductFormModel()
				{
					CategoryId = p.ProductCategoryId,
					Description = p.Description,
					ImageUrl = p.ImageUrl,
					Price = p.Price,
					Title = p.Title
				}).FirstOrDefaultAsync();

			if (product != null)
			{
				product.Categories = await AllProductCategoriesAsync();

			}
			return product;
		}

		public async Task<bool> HasCreatorWithIdAsync(int productId, string userId)
		{
			return await repository.AllReadOnly<Product>()
				.AnyAsync(p => p.Id == productId && p.Creator.UserId == userId);

		}


	}
}
