using CraftHub.Attributes;
using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Course;
using CraftHub.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
	public class CourseController : BaseController
	{
		private readonly ICourseService courseService;

		private readonly ICreatorService creatorService;
		public CourseController(ICourseService _courseService, ICreatorService _creatorService)
		{
			this.courseService = _courseService;
			this.creatorService = _creatorService;
		}

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(AllCoursesModel query)
        {
            var model = await courseService.AllAsync(query.Category);

            return View(model);
        }

        [HttpGet]
		[MustBeCreator]
		public async Task<IActionResult> Add()
		{
			var model = new AddCourseFormModel();
			model.Categories = await courseService.AllCourseCategoriesAsync();

			return View(model);
		}

		[HttpPost]
		[MustBeCreator]
		public async Task<IActionResult> Add(AddCourseFormModel model)
		{
			if (await courseService.CategoryExistsAsync(model.CategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");

			}
			if (ModelState.IsValid == false)
			{
				model.Categories = await courseService.AllCourseCategoriesAsync();

				return View(model);
			}

			int? creatorId = await creatorService.GetCreatorIdAsync(User.Id());

			int newProductId = await courseService.CreateAsync(model, creatorId ?? 0);

			return RedirectToAction(nameof(HomeController.Index), "Home");

		}

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
		{
            if (await courseService.ExistsAsync(id) == false)
            {
                return BadRequest();
			}

            var model = await courseService.CourseDetailsByIdAsync(id);

            return View(model);
        }

    }
}
