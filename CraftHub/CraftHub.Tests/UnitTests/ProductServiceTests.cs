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
    public class ProductServiceTests : UnitTestBase
    {
        private IProductService productService;

        [OneTimeSetUp]
        public void SetUp()
            => productService = new ProductService(repo);

        [Test]
        public async Task MostLikedProductsAsync_ShouldReturnCorrectCount()
        {
            var totalProducts = await productService.MostLikedProductsAsync();

            var totalProductsInTheDatabase= repo.AllReadOnly<Product>().Count();   

            Assert.That(totalProducts.Count(),Is.EqualTo(totalProductsInTheDatabase));
        }

        [Test]
        public async Task AllProductsAsync_ShouldReturnCorrectCount()
        {
            var result =await productService.AllAsync(Product.ProductCategory.Name);

            var total=repo.AllReadOnly<Product>().Where(p=>p.ProductCategory.Name == Product.ProductCategory.Name);

            Assert.That(result.TotalProductsCount,Is.EqualTo(total.Count()));
        }

        [Test]
        public async Task AllProductsAsync_ShouldNotReturnCorrectCount()
        {
            var result = await productService.AllAsync(Product.ProductCategory.Name);

            var total = repo.AllReadOnly<Product>().Where(p => p.ProductCategory.Name == "No Such Category");

            Assert.That(total.Count(), Is.Not.EqualTo(result.TotalProductsCount));
        }

        [Test]
        public async Task AllProductsAsyncWithSearchTerm_ShouldReturnCorrectCount()
        {
            var searchedTerm = Product.Title;

            var result = await productService.AllAsync(Product.ProductCategory.Name, searchedTerm);

            var total = repo.AllReadOnly<Product>().Where(p => p.ProductCategory.Name == Product.ProductCategory.Name);

            Assert.That(result.TotalProductsCount, Is.EqualTo(total.Count()));
        }

        [Test]
        public async Task AllProductsAsyncWithSearchTerm_ShouldNotReturnCorrectCount()
        {
            var searchedTerm = "1";

            var result = await productService.AllAsync(Product.ProductCategory.Name, searchedTerm);

            var total = repo.AllReadOnly<Product>().Where(p => p.ProductCategory.Name == Product.ProductCategory.Name);

            Assert.That(result.TotalProductsCount, Is.EqualTo(0));
        }

        [Test]
        public async Task AllProductsCategories_ShouldReturnCorrectCount()
        {
            var result = await productService.AllProductCategoriesAsync();

            var productCategoriesAll = repo.AllReadOnly<ProductCategory>().Count();

            Assert.That(result.Count(), Is.EqualTo(productCategoriesAll));
        }

        [Test]
        public async Task CategoryExistsAsync_ShouldReturnTrue()
        {
            var result = await productService.CategoryExistsAsync(Product.ProductCategory.Id);

            Assert.That(true, Is.EqualTo(result));
        }

        [Test]
        public async Task CategoryExistsAsync_ShouldReturnFalse()
        {
            var result = await productService.CategoryExistsAsync(123);

            Assert.That(false, Is.EqualTo(result));
        }

        [Test]
        public async Task AllCategoriesNamesAsync_ShouldReturnRightCount()
        {
            var result = await productService.AllCategoriesNamesAsync();

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task AllCategoriesNamesAsync_ShouldReturnRightNames()
        {
            var allCategoryName = await productService.AllCategoriesNamesAsync();

            var result = productService.AllCategoriesNamesAsync().Result.Contains(Product.ProductCategory.Name);


            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnResult()
        {
            var result = await productService.ExistsAsync(3);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalse()
        {
            var result = await productService.ExistsAsync(100);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task AllProductsByCreatorIdAsync_ShouldReturnRightCount()
        {
            var products = await productService.AllProductsByCreatorIdAsync(Creator.Id);

            Assert.That(products.Count(), Is.EqualTo(Creator.Products.Count()));
        }
        [Test]
        public async Task AllProductsByCreatorIdAsync_ShouldReturnRightCountWhenNotHaveProducts()
        {
            var products = await productService.AllProductsByCreatorIdAsync(Creator2.Id);

            Assert.That(products.Count(), Is.EqualTo(Creator2.Products.Count()));
        }



        [Test]
        public async Task HasCreatorWithIdAsync_ShouldReturnTrue()
        {
            var result = await productService.HasCreatorWithIdAsync(Product.Id,Creator.UserId);

            Assert.That(result, Is.EqualTo(false));
        }
        [Test]
        public async Task HasCreatorWithIdAsync_ShouldReturnRightFalse()
        {
            var result = await productService.HasCreatorWithIdAsync(Product.Id, Creator2.UserId);

            Assert.That(result, Is.EqualTo(Creator2.Products.Any(p => p.Id == Product.Id)));
        }

        [Test]
        public async Task DetailsForProduct_ShouldFindRightProduct()
        {
            var productDetails = await productService.ProductDetailsByIdAsync(Product2.Id);

            Assert.That(productDetails.Title, Is.EqualTo(Product2.Title));
        }

        [Test]
        public async Task DeleteProduct_ShouldRemoveProduct()
        {
            var countBeforeDelete = repo.AllReadOnly<Product>().Count();

            await productService.Delete(Product.Id);

            var countAfterDelete = repo.AllReadOnly<Product>().Count();

            Assert.That(countBeforeDelete, Is.EqualTo(countAfterDelete + 1));
        }
    }
}
