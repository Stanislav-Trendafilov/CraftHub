using CraftHub.Core.Contracts;
using CraftHub.Core.Services;
using CraftHub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Tests.UnitTests
{
    public class CartServiceTests : UnitTestBase
    {
        private ICartService cartService;
        private CraftHubDbContext dbContext;

        [OneTimeSetUp]
        public void SetUp()
            => cartService = new CartService(repo,dbContext);
    }
}