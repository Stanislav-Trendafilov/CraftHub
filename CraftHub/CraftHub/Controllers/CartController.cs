using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Cart;
using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
    public class CartController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICartService cartService;

        public CartController(IProductService _productService,ICartService cartService)
        {
            this.productService = _productService;
            this.cartService = cartService;
        }

        public IActionResult ShopCart(string userId)
        {

            string currentUser = User.Id();
            if(currentUser != userId)
            {
                return Unauthorized();
            }

            ShopCartViewModel products = cartService.AllCartProducts(userId);

            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            string userId = User.Id();

            string newUser = await cartService.AddToCartAsync(id,userId);

            return RedirectToAction(nameof(ShopCart), new { userId });
        }

        public async Task<IActionResult> Remove(int id)
		{
            string userId = User.Id();

            string removed = await cartService.RemoveFromCartAsync(id, userId);
           
            return RedirectToAction(nameof(ShopCart), new { userId });
		}
	}
}
