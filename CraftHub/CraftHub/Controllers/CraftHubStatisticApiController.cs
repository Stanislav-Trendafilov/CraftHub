using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
	public class CraftHubStatisticApiController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
