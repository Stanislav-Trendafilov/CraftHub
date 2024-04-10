using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
	public class CreatorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
