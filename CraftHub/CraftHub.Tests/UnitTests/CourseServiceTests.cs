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
    public class CourseServiceTests : UnitTestBase
    {
        private ICourseService courseService;

        [OneTimeSetUp]
        public void SetUp()
            => courseService = new CourseService(repo);

        [Test]
        public async Task AllAsync_ShouldReturnCorrectCount()
        {
            var totalCourses=await courseService.AllAsync();

            var totalCoursesInTheDatabase = repo.AllReadOnly<Course>().Count();

            Assert.That(totalCourses.TotalCoursesCount, Is.EqualTo(totalCoursesInTheDatabase));
        }

        [Test]
        public async Task AllCoursesCategories_ShouldReturnCorrectCount()
        {
            var result = await courseService.AllCourseCategoriesAsync();

            var courseCategoriesAll = repo.AllReadOnly<CourseCategory>().Count();

            Assert.That(result.Count(), Is.EqualTo(courseCategoriesAll));
        }

        [Test]
        public async Task CategoryExistsAsync_ShouldReturnTrue()
        {
            var result = await courseService.CategoryExistsAsync(FirstCourse.CourseCategory.Id);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task CategoryExistsAsync_ShouldReturnFalse()
        {
            var result = await courseService.CategoryExistsAsync(100);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task HasCreatorWithIdAsync_ShouldReturnTrue()
        {
            var result = await courseService.HasCreatorWithIdAsync(FirstCourse.Id, Creator.UserId);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task HasCreatorWithIdAsync_ShouldReturnFalse()
        {
            var result = await courseService.HasCreatorWithIdAsync(FirstCourse.Id, Creator2.UserId);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task HasParticipantWithIdAsync_ShouldReturnTrue()
        {
            var result = await courseService.HasParticipantWithIdAsync(FirstCourse.Id, GuestUser.Id);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task HasParticipantWithIdAsync_ShouldReturnFalse()
        {
            var result = await courseService.HasParticipantWithIdAsync(FirstCourse.Id, Buyer.Id);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task CourseExistsAsync_ShouldReturnTrue()
        {
            var result = await courseService.ExistsAsync(FirstCourse.Id);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task CourseExistsAsync_ShouldReturnFalse()
        {
            var result = await courseService.ExistsAsync(100);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task AllProductsByCreatorIdAsync_ShouldReturnRightCount()
        {
            var courses = await courseService.AllCoursesByCreatorIdAsync(Creator.Id);

            Assert.That(courses.Count(), Is.EqualTo(Creator.Courses.Count()));
        }

        [Test]
        public async Task DetailsForCourse_ShouldFindRightProduct()
        {
            var courseDetails = await courseService.CourseDetailsByIdAsync(FirstCourse.Id);

            Assert.That(courseDetails.Title, Is.EqualTo(FirstCourse.Title));
        }
    }
}
