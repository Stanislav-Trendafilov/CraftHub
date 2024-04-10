using CraftHub.Attributes;
using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Creator;
using static CraftHub.Core.Constants.MessageConstants;
using Microsoft.AspNetCore.Mvc;

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
            if (await creatorService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }


            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await creatorService.CreateAsync(User.Id(), model.PhoneNumber);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
