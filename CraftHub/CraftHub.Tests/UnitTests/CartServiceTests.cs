using CraftHub.Core.Contracts;
using CraftHub.Core.Services;
using CraftHub.Infrastructure.Data.Models;

namespace CraftHub.Tests.UnitTests
{
    [TestFixture]
    public class CartServiceTests : UnitTestBase
    {
        private ICartService cartService;

        [OneTimeSetUp]
        public void SetUp()
            => cartService = new CartService(repo,_data);

        [Test]
        public async Task RemoveFromCartAsync_ShouldDecreaseCount()
        {

            var cart = repo.AllReadOnly<Cart>()
              .FirstOrDefault(cp => cp.BuyerId == Buyer.Id && cp.ProductId == Product.Id);

            Assert.That(1, Is.EqualTo(1));
        }

        [Test]
        public async Task AddToCartAsync_ShouldIncreaseCount()
        {
            var countBeforeAdd = repo.AllReadOnly<Cart>().Count();

            var userId = await cartService.AddToCartAsync(Product2.Id, Buyer.Id);

            var countAfterAdd = repo.AllReadOnly<Cart>().Count();

            Assert.That(countAfterAdd, Is.EqualTo(countBeforeAdd + 1));
        }

        [Test]
        public async Task AllCartProducts_ShouldShowCorrectCountOfProducts()
        {
            var result = cartService.AllCartProducts(Buyer.Id);

            Assert.That(result.products.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task AllCartProducts_ShouldShowReturnCorrectDeliveryPrice()
        {
            var result = cartService.AllCartProducts(Buyer.Id);

            Assert.That(result.Delivery, Is.EqualTo(5));
        }
        [Test]
        public async Task AllCartProducts_ShouldShowReturnCorrectTotalPrice()
        {
            var result = cartService.AllCartProducts(Buyer.Id);

            Assert.That(result.TotalSum, Is.EqualTo(55));
        }


        [Test]
        public async Task AddToCartAsync_ShouldIncreaseCount2()
        {
            var countBeforeAdd = repo.AllReadOnly<Cart>().Count();

            var userId = await cartService.AddToCartAsync(Product2.Id, Creator2.UserId);

            var countAfterAdd = repo.AllReadOnly<Cart>().Count();

            Assert.That(countAfterAdd, Is.EqualTo(countBeforeAdd + 1));
        }

        [Test]
        public async Task AlreadyAddedToCart_ShouldReturnCorrectInfo()
        {
            var result = cartService.AlreadyAddedToCart(Product.Id, Buyer.Id);

            Assert.AreEqual(result, true);
        }

        [Test]
        public async Task AlreadyAddedToCart_ShouldReturnCorrectInfoWhenNotAdded()
        {
            var result = cartService.AlreadyAddedToCart(Product2.Id, Creator.UserId);

            Assert.AreEqual(result, false);
        }


    }
}