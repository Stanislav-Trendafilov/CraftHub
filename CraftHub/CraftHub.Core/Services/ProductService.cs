using CraftHub.Core.Contracts;
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

		
	}
}
