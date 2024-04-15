using CraftHub.Core.Contracts;
using CraftHub.Data;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CraftHub.Controllers
{
    public class CartController : BaseController
    {
        private readonly IProductService productService;

        private readonly CraftHubDbContext data;
        public CartController(IProductService _productService, CraftHubDbContext _data)
        {
            this.productService = _productService;
            this.data = _data;
        }

        public IActionResult ShopCart(string userId)
        {
            var productIds= data.Carts.Where(c => c.BuyerId == userId)
                .Select(c => c.ProductId)
                .ToList();

            var products  =new List<Product>();

            foreach (var product in data.Products)
            {
                 if(productIds.Contains(product.Id))
                 {
                     products.Add(product);
                 }
            }
			return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var product = data.Products.Where(c => c.Id == id).FirstOrDefault();

            if (product == null)
            {
                return BadRequest();
            }

            string userId = User.Id();

            Cart cart = new Cart()
            {
                BuyerId= userId,
                ProductId= product.Id  
            };
            
            data.Carts.Add(cart);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(ShopCart),new { userId});
        }

		public async Task<IActionResult> Remove(int id)
		{
			var product = data.Products.Where(c => c.Id == id).FirstOrDefault();

			if (product == null)
			{
				return BadRequest();
			}

			string userId = User.Id();

			var cp = data.Carts
				.FirstOrDefault(cp => cp.BuyerId == userId);

			if (cp == null)
			{
				return BadRequest();
			}

			data.Carts.Remove(cp);

			await data.SaveChangesAsync();

			return RedirectToAction(nameof(ShopCart), new { userId });
		}
	}
}
