using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Main()
        {
            return View();
        }

    }
}
