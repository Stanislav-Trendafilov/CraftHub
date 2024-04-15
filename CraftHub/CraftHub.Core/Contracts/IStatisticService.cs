using CraftHub.Core.Models.CraftHubStatistic;

namespace CraftHub.Core.Contracts
{
	public interface IStatisticService
	{
		Task<StatisticServiseModel> TotalAsync();
	}
}
