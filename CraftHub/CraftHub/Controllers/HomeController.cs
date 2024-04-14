using CraftHub.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
    public class HomeController : BaseController
	{

        private readonly IProductService productService;

        public HomeController(IProductService _productService)
        {
            this.productService = _productService;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
		{
            var models = await productService.MostLikedProductsAsync();

            return View(models);
        }

		[AllowAnonymous]
		public async Task<IActionResult> Contacts()
		{
			return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }
            return View();
        }

	}
}