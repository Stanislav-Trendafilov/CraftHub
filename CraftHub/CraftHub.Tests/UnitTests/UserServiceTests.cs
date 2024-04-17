using CraftHub.Core.Contracts;
using CraftHub.Core.Services;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Tests.UnitTests
{
    [TestFixture]
    public class UserServiceTests : UnitTestBase
    {
        private IUserService userService;

        [OneTimeSetUp]
        public void SetUp()
            => userService = new UserService(repo);

        [Test]
        public async Task AllUsersAsync_ShowsCorrectInfo()
        {
            var totalCount =await userService.AllAsync();

            var totalUsersInDatabase=repo.AllReadOnly<IdentityUser>().Count(); 

            Assert.AreEqual(totalCount.Count(), totalUsersInDatabase+1);
        }

        [Test]
        public async Task ProductCategoryExistsAsync_ShowsCorrectResult()
        {
            var result =await userService.ProductCategoryExistsAsync(Product.ProductCategory.Name);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task CreateProductCategoryAsync_ShowsCorrectResult()
        {
             var categoriesCountBeforeAdd = repo.AllReadOnly<ProductCategory>().Count();

             var productCategory = await userService.CreateProductCategoryAsync("newProductCategory");

            var categoriesCountAfterAdd = repo.AllReadOnly<ProductCategory>().Count();

             Assert.That(categoriesCountAfterAdd, Is.EqualTo(categoriesCountBeforeAdd+1));
        }

        [Test]
        public async Task CourseCategoryExistsAsync_ShowsCorrectResult()
        {
            var result = await userService.CourseCategoryExistsAsync(FirstCourse.CourseCategory.Name);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task CreateCourseCategoryAsync_ShowsCorrectResult()
        {
            var categoriesCountBeforeAdd = repo.AllReadOnly<CourseCategory>().Count();

            var courseCategory = await userService.CreateCourseCategoryAsync("newCourseCategory");

            var categoriesCountAfterAdd = repo.AllReadOnly<CourseCategory>().Count();

            Assert.That(categoriesCountAfterAdd, Is.EqualTo(categoriesCountBeforeAdd + 1));
        }

    }
}
