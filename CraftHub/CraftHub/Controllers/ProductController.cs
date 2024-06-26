﻿using CraftHub.Attributes;
using CraftHub.Core.Contracts;
using CraftHub.Core.Extensions;
using CraftHub.Core.Models.Product;
using Microsoft.AspNetCore.Authorization;
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

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllProductsQueryModel query)
		{
			var model = await productService.AllAsync(
				query.Category,
				query.SearchTerm,
				query.Sorting,
				query.CurrentPage,
				query.ProductsPerPage);

			query.TotalProductsCount = model.TotalProductsCount;
			query.Products = model.Products;
			query.Categories = await productService.AllCategoriesNamesAsync();

			return View(query);
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

			return RedirectToAction(nameof(My));
		}

		[AllowAnonymous]
        public async Task<IActionResult> Details(int id,string information)
        {
            if (await productService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await productService.ProductDetailsByIdAsync(id);

			if(information!=model.GetInformation())
			{
				return BadRequest();
			}
            return View(model);
        }

		public async Task<IActionResult> My()
		{
			var userId = User.Id();
			IEnumerable<ProductServiceModel> model;

			var creatorId = await creatorService.GetCreatorIdAsync(userId) ?? 0;
			model = await productService.AllProductsByCreatorIdAsync(creatorId);

			return View(model);
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (await productService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await productService.HasCreatorWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin()==false)
			{
				return Unauthorized();
			}


			var model = await productService.GetProductFormModelByIdAsync(id);

			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, AddProductFormModel model)
		{
			if (await productService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await productService.HasCreatorWithIdAsync(id, User.Id()) == false 
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}
			if (await productService.CategoryExistsAsync(model.CategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
			}

			if (ModelState.IsValid == false)
			{
				model.Categories = await productService.AllProductCategoriesAsync();

				return View(model);
			}
			await productService.EditAsync(id, model);

			return RedirectToAction(nameof(Details), new { id ,Information=model.GetInformation()});
		}

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await productService.HasCreatorWithIdAsync(id, User.Id()) == false  
				&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var product = await productService.ProductDetailsByIdAsync(id);

            var model = new ProductDetailsServiceModel()
            {
                Id = id,
                ImageUrl = product.ImageUrl,
				Description=product.Description,
                Title = product.Title,
				Price=product.Price,
				Category=product.Category
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDetailsServiceModel model)
        {
            if (await productService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await productService.HasCreatorWithIdAsync(model.Id, User.Id()) == false 
				&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await productService.Delete(model.Id);

            return RedirectToAction(nameof(My));
        }
    }
}
