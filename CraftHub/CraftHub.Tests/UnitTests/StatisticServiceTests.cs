using CraftHub.Core.Contracts;
using CraftHub.Core.Services;
using CraftHub.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Tests.UnitTests
{
    public class StatisticServiceTests : UnitTestBase
    {
        private IStatisticService statisticService;

        [OneTimeSetUp]
        public void SetUp()
            => statisticService = new StatisticService(repo);

        [Test]
        public async Task Total_ShouldReturnCorrectProductsCount()
        {
            var result = await statisticService.TotalAsync();

            Assert.IsNotNull(result);

            var productsCount=repo.AllReadOnly<Product> ().Count();

            Assert.That(result.TotalProducts, Is.EqualTo(productsCount));
        }

        [Test]
        public async Task Total_ShouldReturnCorrectUsersCreatorsCount()
        {
            var result = await statisticService.TotalAsync();

            Assert.IsNotNull(result);

            var creatorsCount = repo.AllReadOnly<Creator>().Count();

            Assert.That(result.TotalUsers, Is.EqualTo(creatorsCount));
        }

        [Test]
        public async Task Total_ShouldReturnCorrectCoursesCount()
        {
            var result = await statisticService.TotalAsync();

            Assert.IsNotNull(result);

            var coursesCount = repo.AllReadOnly<Course>().Count();

            Assert.That(result.TotalCourses, Is.EqualTo(coursesCount));
        }
    }

}
