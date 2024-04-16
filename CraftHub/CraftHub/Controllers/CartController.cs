using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Product;
using CraftHub.Data;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CraftHub.Controllers
{
    public class CartController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICartService cartService;

        private readonly CraftHubDbContext data;
        public CartController(IProductService _productService, CraftHubDbContext _data, ICartService cartService)
        {
            this.productService = _productService;
            this.data = _data;
            this.cartService = cartService;
        }

        public IActionResult ShopCart(string userId)
        {
           
            List<ProductServiceModel> products = cartService.AllCartProducts(userId);

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
