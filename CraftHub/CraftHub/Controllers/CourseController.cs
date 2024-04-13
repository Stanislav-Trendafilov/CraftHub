using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
	public class CourseController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
