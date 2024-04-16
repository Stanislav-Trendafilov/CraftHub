using CraftHub.Areas.Admin.Controllers;
using CraftHub.Attributes;
using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Product;
using CraftHub.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
    public class UserController : AdminBaseController
    {
        private IProductService productService;
        private ICourseService courseService;

        private readonly IUserService _users;
        public UserController(IUserService users, IProductService productService, ICourseService courseService)
        {
            _users = users;
            this.productService = productService;
            this.courseService = courseService;
        }

        [Route("User/All")]
        public async Task<IActionResult>All()
        {
            var users = await _users.AllAsync();

            return View(users);
        }


        //[HttpPost]
        //public async Task<IActionResult> AddProductCategory(int productCategory,int id)
        //{
        //    if (await productService.CategoryExistsAsync(id) == true)
        //    {
        //        ModelState.AddModelError(nameof(id), "Category already exists");
        //    }

        //    int newProductId = await productService.CreateAsync(model, creatorId ?? 0);

        //    return RedirectToAction(nameof(My));
        //}
    }
}
