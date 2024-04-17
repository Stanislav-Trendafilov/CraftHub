using CraftHub.Areas.Admin.Controllers;
using CraftHub.Attributes;
using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Course;
using CraftHub.Core.Models.Product;
using CraftHub.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
    public class UserController : AdminBaseController
    {
        private IProductService productService;
        private ICourseService courseService;

        private IUserService users;
        public UserController(IUserService _users, IProductService productService, ICourseService courseService)
        {
            this.users = _users;
            this.productService = productService;
            this.courseService = courseService;
        }

        [Route("User/All")]
        public async Task<IActionResult>All()
        {
            var _users = await users.AllAsync();

            return View(_users);
        }

		[HttpGet]
        [Route("User/AddProductCategory")]
        public async Task<IActionResult> AddProductCategory()
		{
            var model = new ProductCategoryServiceModel();

			return View(model);
		}

		[HttpPost]
		[Route("User/AddProductCategory")]
		public async Task<IActionResult> AddProductCategory(ProductCategoryServiceModel productCategory)
        {
            if (await users.ProductCategoryExistsAsync(productCategory.Name) == true)
            {
                ModelState.AddModelError(nameof(productCategory.Name), "Category already exists");
                return BadRequest();
            }

            int newProductId = await users.CreateProductCategoryAsync(productCategory.Name);

            return RedirectToAction("Main", "Home", new {area="Admin"});
        }

        [HttpGet]
        [Route("User/AddCourseCategory")]
        public async Task<IActionResult> AddCourseCategory()
        {
            var model = new CourseCategoryServiceModel();

            return View(model);
        }

        [HttpPost]
        [Route("User/AddCourseCategory")]
        public async Task<IActionResult> AddCourseCategory(CourseCategoryServiceModel productCategory)
        {
            if (await users.CourseCategoryExistsAsync(productCategory.Name) == true)
            {
                ModelState.AddModelError(nameof(productCategory.Name), "Category already exists");
                return BadRequest();
            }

            int newCourseId = await users.CreateCourseCategoryAsync(productCategory.Name);

            return RedirectToAction("Main", "Home", new { area = "Admin" });
        }
    }
}
