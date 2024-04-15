using CraftHub.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{

	[Route("api/statistic")]
	[ApiController]
	public class CraftHubStatisticApiController : BaseController
	{
		private readonly IStatisticService statisticService;

		public CraftHubStatisticApiController(IStatisticService _statisticService)
		{
			statisticService = _statisticService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetStatistic()
		{
			var result = await statisticService.TotalAsync();

			return Ok(result);
		}
	}
}
