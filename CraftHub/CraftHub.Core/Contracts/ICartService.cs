using CraftHub.Core.Models.Product;
using CraftHub.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Core.Contracts
{
    public interface ICartService
    {
        Task<string> AddToCartAsync(int productId, string userId);

        Task<string> RemoveFromCartAsync(int productId, string userId);

        List<ProductServiceModel> AllCartProducts(string userId);
    }
}
