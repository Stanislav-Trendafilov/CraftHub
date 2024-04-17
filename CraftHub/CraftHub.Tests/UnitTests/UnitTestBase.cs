using CraftHub.Data;
using CraftHub.Infrastructure.Data.Models;
using CraftHub.Tests.Mocks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Tests.UnitTests
{
    public class UnitTestBase
    {
        protected CraftHubDbContext _data;

        [OneTimeSetUp]
        protected void SetUpBase()
        {
            _data = DatabaseMock.Instance;
            SeedDatabase();
        }

        public IdentityUser Buyer { get; private set; } 
        public Creator Creator { get; private set; }
        public Product Product { get; private set; }
        public Course Course { get; private set; }

        private void SeedDatabase()
        {
            Buyer = new IdentityUser
            {
                Id = "BuyerUserId",
                Email = "buyer@mail.com"
            };
            _data.Users.Add(Buyer);

            Creator = new Creator
            {
                PhoneNumber = "+35999999999",
                FullName = "Creator Creatarov",
                BusinessName = "CreateLand",
                Website = "no eisting",
                MoreInformation="no more info",
                User = new IdentityUser
                {
                    Id = "CreatorUserId",
                    Email = "creatorUser@mail.com"
                }
            };
            _data.Creators.Add(Creator);

            //Product = new Product
            //{
            //    Title= "First Test Product",

            //}


        }
        [OneTimeTearDown]
        public void TearDownBase()
            =>_data.Dispose();
    }
}
