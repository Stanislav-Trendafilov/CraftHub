using CraftHub.Core.Models.Cart;

namespace CraftHub.Core.Contracts
{
    public interface ICartService
    {
        Task<string> AddToCartAsync(int productId, string userId);

        Task<string> RemoveFromCartAsync(int productId, string userId);

        ShopCartViewModel AllCartProducts(string userId);

        bool AlreadyAddedToCart(int productId, string userId);
    }
}
