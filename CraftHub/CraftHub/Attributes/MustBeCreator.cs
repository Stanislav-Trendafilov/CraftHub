using CraftHub.Controllers;
using CraftHub.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CraftHub.Attributes
{
	public class MustBeCreator : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			base.OnActionExecuted(context);

			ICreatorService? creatorService = context.HttpContext.RequestServices.GetService<ICreatorService>();

			if (creatorService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

			if (creatorService != null && creatorService.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
			{
				context.Result = new RedirectToActionResult(nameof(CreatorController.Become), "Creator", null);
			}
		}
	}
}
