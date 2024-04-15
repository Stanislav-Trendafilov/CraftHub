using CraftHub.Core.Contracts;
using CraftHub.Core.Models.CraftHubStatistic;
using CraftHub.Infrastructure.Data.Common;
using CraftHub.Infrastructure.Data.Models;

namespace CraftHub.Core.Services
{
	public class StatisticService : IStatisticService
	{
		private readonly IRepository repository;

		public StatisticService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<StatisticServiseModel> TotalAsync()
		{
			int totalProducts = repository.AllReadOnly<Product>().Count();

			int totalCourses = repository.AllReadOnly<Course>().Count();

			int totalCreators= repository.AllReadOnly<Creator>().Count();

			return new StatisticServiseModel()
			{
				TotalProducts = totalProducts,
				TotalCourses= totalCourses,
				TotalUsers=totalCreators
			};
		}
	}
}
