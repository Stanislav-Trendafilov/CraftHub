using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Course;
using CraftHub.Core.Models.Product;
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
        public async Task EditCoursesAsync_ShouldReturnCorrectEditedTitle()
        {

            var editCourse = new AddCourseFormModel()
            {
                Title = "Edited Title"
            };

            await courseService.EditAsync(FirstCourse.Id, editCourse);

            Assert.That(editCourse.Title, Is.EqualTo(FirstCourse.Title));
        }
        [Test]
        public async Task EditProductsAsync_ShouldReturnCorrectEditedDescription()
        {

            var editProduct = new AddCourseFormModel()
            {
                Details = "Edited Description"
            };

            await courseService.EditAsync(FirstCourse.Id, editProduct);

            Assert.That(editProduct.Details, Is.EqualTo(FirstCourse.Details));
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

        [Test]
        public async Task CreateCourseAsync_ShouldReturnCorrectNewCount()
        {
            var totalCoursesBefore = repo.AllReadOnly<Course>().Count();

            var addedCourse = new AddCourseFormModel()
            {
                Title = "Added Course Title"
            };

            await courseService.CreateAsync(addedCourse, Creator2.Id);

            var totalCoursesAfter = repo.AllReadOnly<Course>().Count();

            Assert.That(totalCoursesBefore, Is.EqualTo(totalCoursesAfter - 1));
        }

        [Test]
        public async Task GetCourseFormModelByIdAsync_ShouldReturnCorrectValue()
        {
            var result = await courseService.GetCourseFormModelByIdAsync(FirstCourse.Id);

            Assert.That(result.Title, Is.EqualTo(FirstCourse.Title));
        }

        [Test]
        public async Task GetCourseFormModelByIdAsync_ShouldReturnFalseValue()
        {
            var result = await courseService.GetCourseFormModelByIdAsync(FirstCourse.Id);

            Assert.That(result.Title, Is.Not.EqualTo("No existing title"));
        }
    }
}
