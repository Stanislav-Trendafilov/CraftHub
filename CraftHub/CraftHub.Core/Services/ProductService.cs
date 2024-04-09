using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Home;
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

    }
}
