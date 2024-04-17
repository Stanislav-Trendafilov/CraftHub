using CraftHub.Data;
using CraftHub.Infrastructure.Data.Common;
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
        protected IRepository repo;

        [OneTimeSetUp]
        protected void SetUpBase()
        {
            _data = DatabaseMock.Instance;
            this.repo = new Repository(this._data);
            SeedDatabase();
        }

        
        public IdentityUser Buyer { get; private set; }
        public IdentityUser CreatorUser { get; set; }
        public IdentityUser GuestUser { get; set; }
        public IdentityUser AdminUser { get; set; }

        public Creator Creator { get; set; }
        public Creator Creator2 { get; private set; }
        public Creator AdminCreator { get; set; }


        public Product Product { get; private set; }
        public Cart Cart { get; private set; }


        public CourseCategory PaintingCourse { get; set; }
        public CourseCategory CarvingCourse { get; set; }
        public CourseCategory SculpturingCourse { get; set; }

        public Course FirstCourse { get; set; }
        public Course SecondCourse { get; set; }


        public CourseParticipant FirstCourseParticipant { get; set; }
        public CourseParticipant SecondCourseParticipant { get; set; }


        private void SeedDatabase()
        {
            //Seed Users
            Buyer = new IdentityUser
            {
                Id = "BuyerUserId",
                Email = "buyer@mail.com"
            };
            _data.Users.Add(Buyer);

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };
            _data.Users.Add(GuestUser);

            CreatorUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "creator@mail.com",
                NormalizedUserName = "creator@mail.com",
                Email = "creator@mail.com",
                NormalizedEmail = "creator@mail.com"
            };
            _data.Users.Add(CreatorUser);

            AdminUser = new IdentityUser()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM"
            };
            _data.Users.Add(AdminUser);

            //Seed Creators
            Creator = new Creator()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                FullName = "Daniel Atanasov",
                BusinessName = "Rezbart",
                Email = CreatorUser.Email,
                Website = "https://www.facebook.com/rezbart.bg",
                UserId = CreatorUser.Id
            };
            _data.Creators.Add(Creator);

            Creator2 = new Creator
            {
                Id=2,
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
            _data.Creators.Add(Creator2);

            AdminCreator = new Creator()
            {
                Id = 3,
                PhoneNumber = "+359888789000",
                FullName = "Stanislav Trendafilov",
                BusinessName = "CraftHub",
                Email = AdminUser.Email,
                Website = "https://github.com/Stanislav-Trendafilov/CraftHub/tree/master/CraftHub",
                UserId = AdminUser.Id
            };
            _data.Creators.Add(AdminCreator);

            //Seed Products
            Product = new Product
            {
                Id = 1,
                Title = "First Test Product",
                Description = "No time to add description",
                Price = 50.00m,
                ImageUrl = "https://static.wixstatic.com/media/65039e_016abad6177c4bb38aa79fc61ab53e1a~mv2.jpg/v1/fill/w_640,h_744,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/65039e_016abad6177c4bb38aa79fc61ab53e1a~mv2.jpg",
                ProductCategory = new ProductCategory() { Name = "Art" },
                Creator = Creator2
            };
            _data.Products.Add(Product);

            //Seed CourseCategories
            PaintingCourse = new CourseCategory()
            {
                Id = 1,
                Name = "Painting Course"
            };
            _data.CourseCategories.Add(PaintingCourse);

            CarvingCourse = new CourseCategory()
            {
                Id = 2,
                Name = "Carving Course"
            };
            _data.CourseCategories.Add(CarvingCourse);

            SculpturingCourse = new CourseCategory()
            {
                Id = 3,
                Name = "Sculpturing Course"
            };
            _data.CourseCategories.Add(SculpturingCourse);

            //Seed Courses
            FirstCourse = new Course()
            {
                Id = 1,
                Title = "Working with common tools",
                Details = "Introduction in the world of creatng.",
                CreatorId = Creator.Id,
                Location = "Veliko Tarnovo",
                CourseCategoryId = CarvingCourse.Id,
                Duration = 3
            };
            _data.Courses.Add(FirstCourse);

            SecondCourse = new Course()
            {
                Id = 2,
                Title = "Working with advanced tools",
                Details = "Start dealing with toold which need more experience in this sphere of creating.",
                CreatorId = Creator.Id,
                Location = "Veliko Tarnovo",
                CourseCategoryId = CarvingCourse.Id,
                Duration = 6
            };
            _data.Courses.Add(SecondCourse);

            //Seed CourseParticipants
            FirstCourseParticipant = new CourseParticipant()
            {
                ParticipantId = GuestUser.Id,
                CourseId = FirstCourse.Id
            };
            _data.CoursesParticipant.Add(FirstCourseParticipant);

            SecondCourseParticipant = new CourseParticipant()
            {
                ParticipantId = GuestUser.Id,
                CourseId = SecondCourse.Id
            };
            _data.CoursesParticipant.Add(SecondCourseParticipant);

            //   Seed Carts
            Cart = new Cart
            {
                Buyer = Buyer,
                Product = Product
            };
            _data.Carts.Add(Cart);

            _data.SaveChanges();

        }

        [OneTimeTearDown]
        public void TearDownBase()
            =>_data.Dispose();
    }
}
