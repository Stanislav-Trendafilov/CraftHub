using CraftHub.Attributes;
using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
	public class ProductController : BaseController
	{
		private readonly IProductService productService;

		private readonly ICreatorService creatorService;
		public ProductController(IProductService _productService, ICreatorService _creatorService)
		{
			this.productService = _productService;
			this.creatorService = _creatorService;
		}

		[HttpGet]
		[MustBeCreator]
		public async Task<IActionResult> Add()
		{
			var model = new AddProductFormModel()
			{
				Categories = await productService.AllProductCategoriesAsync()
			};

			return View(model);
		}

		[HttpPost]
		[MustBeCreator]
		public async Task<IActionResult> Add(AddProductFormModel model)
		{
			if (await productService.CategoryExistsAsync(model.CategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");

			}
			if (ModelState.IsValid == false)
			{
				model.Categories = await productService.AllProductCategoriesAsync();

				return View(model);
			}

			int? creatorId = await creatorService.GetCreatorIdAsync(User.Id());

			int newProductId = await productService.CreateAsync(model, creatorId ?? 0);

			return RedirectToAction(nameof(HomeController.Index), "Home", null);
		}
	}
}
