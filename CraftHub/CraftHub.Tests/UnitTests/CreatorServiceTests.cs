using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Creator;
using CraftHub.Core.Services;
using CraftHub.Infrastructure.Data.Models;

namespace CraftHub.Tests.UnitTests
{
    public class CreatorServiceTests : UnitTestBase
    {
        private ICreatorService creatorService;

        [OneTimeSetUp]
        public void SetUp()
            => creatorService = new CreatorService(repo);

        [Test]
        public async Task GetCreatorId_ShouldReturnCorrectUserId()
        {
            var resultCreatorId = await creatorService.GetCreatorIdAsync(Creator2.UserId);

            Assert.That(Convert.ToInt32(resultCreatorId), Is.EqualTo(Creator2.Id));
        }

        [Test]
        public async Task UserWithPhoneNumberExistsAsync_ShouldReturnTrue()
        {
            var result = await creatorService.UserWithPhoneNumberExistsAsync(Creator2.PhoneNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task UserWithPhoneNumberExistsAsync_ShouldReturnFalse()
        {
            var result = await creatorService.UserWithPhoneNumberExistsAsync(GuestUser.PhoneNumber);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task ExistByIdAsync_ShouldReturnTrue()
        {
            var result = await creatorService.ExistByIdAsync(Creator2.UserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistByIdAsync_ShouldReturnFalse()
        {
            var result = await creatorService.ExistByIdAsync(GuestUser.Id);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewCreator()
        {
            var creatorCountBefore = repo.AllReadOnly<Creator>().Count();

            BecomeCreatorFormModel formModel= new BecomeCreatorFormModel()
            {
                PhoneNumber=Creator.PhoneNumber,
                Email=Creator.Email,
                BusinessName=Creator.BusinessName,
                FullName=Creator.FullName,
                MoreInformation=Creator.MoreInformation,
                Website=Creator.Website
            };

            await creatorService.CreateAsync(Creator.UserId,formModel);

            var creatorCountAfter = repo.AllReadOnly<Creator>().Count();

            Assert.That(creatorCountAfter, Is.EqualTo(creatorCountBefore + 1));

        }

        [Test]
        public async Task CreateAsync_ShouldNotAddExistingreator()
        {
            var creatorCountBefore = repo.AllReadOnly<Creator>().Count();

            BecomeCreatorFormModel formModel = new BecomeCreatorFormModel()
            {
                PhoneNumber = Creator.PhoneNumber,
                Email = Creator.Email,
                BusinessName = Creator.BusinessName,
                FullName = Creator.FullName,
                MoreInformation = Creator.MoreInformation,
                Website = Creator.Website
            };

            await creatorService.CreateAsync(Creator.UserId, formModel);

            if(!await creatorService.ExistByIdAsync(Creator.UserId))
            {
                await creatorService.CreateAsync(Creator.UserId, formModel);
            }

            var creatorCountAfter = repo.AllReadOnly<Creator>().Count();

            Assert.That(creatorCountAfter, Is.EqualTo(creatorCountBefore + 1));

        }

        [Test]
        public async Task CreateAsync_UserIsCreatedWithCorrectData()
        {
            BecomeCreatorFormModel formModel = new BecomeCreatorFormModel()
            {
                PhoneNumber = Creator.PhoneNumber,
                Email = Creator.Email,
                BusinessName = Creator.BusinessName,
                FullName = Creator.FullName,
                MoreInformation = Creator.MoreInformation,
                Website = Creator.Website
            };

            await creatorService.CreateAsync(Creator.UserId, formModel);

            var newCreatorId = await creatorService.GetCreatorIdAsync(Creator.UserId);
            var newCreatorInDb = await repo.GetByIdAsync<Creator>(Creator.Id);

            Assert.IsNotNull(newCreatorInDb);
            Assert.That(newCreatorInDb.UserId, Is.EqualTo(Creator.UserId));
            Assert.That(newCreatorInDb.PhoneNumber, Is.EqualTo(Creator.PhoneNumber));
        }

    }
}
