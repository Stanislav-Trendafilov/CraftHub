using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CraftHub.Core.Contracts;

namespace CraftHub.Attributes
{
    public class NotACreatorAttribute  : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            ICreatorService? creatorService = context.HttpContext.RequestServices.GetService<ICreatorService>();

            if (creatorService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            //if (creatorService != null && creatorService.ExistByIdAsync(context.HttpContext.User.Id()).Result)
            //{
            //    context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            //}
        }
    }
}
