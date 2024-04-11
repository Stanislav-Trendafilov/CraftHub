using CraftHub.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
	public class ProductController : BaseController
	{
		private readonly IProductService productService;
		public ProductController(IProductService _productService)
		{
			this.productService = _productService;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
