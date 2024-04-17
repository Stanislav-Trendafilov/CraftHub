using CraftHub.Attributes;
using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Course;
using CraftHub.Data;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CraftHub.Controllers
{
    public class CourseController : BaseController
	{
		private readonly ICourseService courseService;

		private readonly ICreatorService creatorService;

        private readonly CraftHubDbContext data;
        public CourseController(ICourseService _courseService, ICreatorService _creatorService,CraftHubDbContext _data)
		{
			this.courseService = _courseService;
			this.creatorService = _creatorService;
            this.data = _data;
		}

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(AllCoursesModel query)
        {
            var model = await courseService.AllAsync(query.Category);

            return View(model);
        }

		public async Task<IActionResult> My()
		{
			var userId = User.Id();
			IEnumerable<CourseServiceModel> model2;

            var model = await data.CoursesParticipant
                .Where(cp => cp.ParticipantId == userId)
                .AsNoTracking()
                .Select(cp => new CourseServiceModel
                {
                    Id = cp.CourseId,
                    Title = cp.Course.Title,
                    Lecturer = cp.Course.Lecturer,
                    Duration= cp.Course.Duration,
                    Details= cp.Course.Details,
                    Location= cp.Course.Location

                }).ToListAsync(); 


            var creatorId = await creatorService.GetCreatorIdAsync(userId) ?? 0;
			model2 = (await courseService.AllCoursesByCreatorIdAsync(creatorId)).ToList();

            var model3 = new List<CourseServiceModel>();
            foreach (var item in model)
            {
                model3.Add(item);
            }
            foreach (var item in model2)
            {
                model3.Add(item);
            }


            return View(model3);
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

			return RedirectToAction(nameof(My));

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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await courseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await courseService.HasCreatorWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
			{
                return Unauthorized();
            }


            var model = await courseService.GetCourseFormModelByIdAsync(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddCourseFormModel model)
        {
            if (await courseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await courseService.HasCreatorWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            if (await courseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await courseService.AllCourseCategoriesAsync();

                return View(model);
            }
            await courseService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var course = await data.Courses
                .Where(c => c.Id == id)
                .Include(c => c.CourseParticipants)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return BadRequest();
            }

            string userId = User.Id();


            if (!course.CourseParticipants.Any(cp => cp.ParticipantId == userId))
            {
                course.CourseParticipants.Add(new CourseParticipant()
                {
                    CourseId = course.Id,
                    ParticipantId = userId
                });

                await data.SaveChangesAsync();
            }
            else
            {
                return RedirectToAction(nameof(All));
            }


            return RedirectToAction(nameof(My));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var course = await data.Courses
                .Where(c => c.Id == id)
                .Include(c => c.CourseParticipants)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return BadRequest();
            }

            string userId = User.Id();

            var cp = course.CourseParticipants
                .FirstOrDefault(cp => cp.ParticipantId == userId);

            if (cp == null)
            {
                return BadRequest();
            }

            course.CourseParticipants.Remove(cp);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(My));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var course = data.Courses.Find(id);

            if (course == null)
            {
                return BadRequest();
            }

            string userId = User.Id();

			if (await courseService.HasCreatorWithIdAsync(id, userId) == false
			   && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var model = new CourseDetailsModel()
            {
                Id = id,
                Details = course.Details,
                Title = course.Title,
                Duration = course.Duration
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = data.Courses
                .Include(s => s.CourseParticipants)
                .FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return BadRequest();
            }

			string userId = User.Id();

			if (await courseService.HasCreatorWithIdAsync(id, userId) == false
			   && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			if (course.CourseParticipants.Any())
            {
                List<CourseParticipant> courseParticipants = data.CoursesParticipant.Where(cp => cp.CourseId == course.Id).ToList();
                data.CoursesParticipant.RemoveRange(courseParticipants);
            }
            data.Courses.Remove(course);
            data.SaveChanges();

            return RedirectToAction(nameof(My));
        }
    }
}
