using CraftHub.Attributes;
using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Home;
using Microsoft.AspNetCore.Mvc;
using static CraftHub.Core.Constants.MessageConstants;

namespace CraftHub.Controllers
{
    public class CreatorController : BaseController
	{
		private readonly ICreatorService creatorService;

		public CreatorController(ICreatorService _creatorService)
		{
			creatorService = _creatorService;
		}
		[HttpGet]
        [NotACreator]
        public IActionResult Become()
        {
            var model = new BecomeCreatorFormModel();

            return View(model);
        }

        [HttpPost]
        [NotACreator]
        public async Task<IActionResult> Become(BecomeCreatorFormModel model)
        {
			var userId = User.Id();

			if (await creatorService.ExistByIdAsync(User.Id()))
            {
                return BadRequest("You are already creator");
            }

            if (await creatorService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }


            if (!ModelState.IsValid )
            {
                return View(model);
            }

            await creatorService.CreateAsync(userId, model);

            return RedirectToAction(nameof(HomeController.Index),"Home");
        }

		
	}
}
