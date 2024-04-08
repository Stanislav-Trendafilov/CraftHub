using CraftHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CraftHub.Data
{
	public class SeedData
	{
		public SeedData()
		{
			SeedUsers();

			SeedCreators();		
			SeedProductCategories();
			SeedProducts();

			SeedCourseCategories();
			SeedCourses();
			SeedLections();

		}

		public IdentityUser CreatorUser { get; set; }
		public IdentityUser GuestUser { get; set; }

		public Creator Creator { get; set; }

		public ProductCategory PaintingCategory { get; set; }
		public ProductCategory CarvingCategory { get; set; }
		public ProductCategory SculpturingCategory { get; set; }

		public Product FirstProduct { get; set; }
		public Product SecondProduct { get; set; }

		public CourseCategory PaintingCourse { get; set; }
		public CourseCategory CarvingCourse { get; set; }
		public CourseCategory SculpturingCourse { get; set; }

		public Course FirstCourse { get; set; }
		public Course SecondCourse { get; set; }

		public Lection WorkingWithHammer { get; set; }
		public Lection WorkingWithEngraver { get; set; }


		private void SeedUsers()
		{
			var hasher = new PasswordHasher<IdentityUser>();

			CreatorUser = new IdentityUser()
			{
				Id = "dea12856-c198-4129-b3f3-b893d8395082",
				UserName = "creator@mail.com",
				NormalizedUserName = "creator@mail.com",
				Email = "creator@mail.com",
				NormalizedEmail = "creator@mail.com"
			};

			CreatorUser.PasswordHash =
				 hasher.HashPassword(CreatorUser, "creator123");

			GuestUser = new IdentityUser()
			{
				Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
				UserName = "guest@mail.com",
				NormalizedUserName = "guest@mail.com",
				Email = "guest@mail.com",
				NormalizedEmail = "guest@mail.com"
			};

			GuestUser.PasswordHash =
				hasher.HashPassword(GuestUser, "guest123");
		}
		private void SeedCreators()
		{
			Creator = new Creator()
			{
				Id=CreatorUser.Id,
				PhoneNumber = "+359888888888",
				FullName="Daniel Atanasov",
				BusinessName="Rezbart",
				Email=CreatorUser.Email,
				Website= "https://www.facebook.com/rezbart.bg",
				UserId = CreatorUser.Id
			};
		}		
		private void SeedProductCategories()
		{
			PaintingCategory = new ProductCategory()
			{
				Id = 1,
				Name = "Painting"
			};

			CarvingCategory = new ProductCategory()
			{
				Id = 2,
				Name = "Carving"
			};

			SculpturingCategory = new ProductCategory()
			{
				Id = 3,
				Name = "Sculpturing"
			};
		}
		private void SeedProducts()
		{
			FirstProduct = new Product()
			{
				Id = 1,
				Title = "Restavrated Axe",
				Description = "Light restoration of an axe with pyrographing Dulot's mark.",
				ImageUrl = "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/434946900_973518331450547_6779376460553241297_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=5f2048&_nc_ohc=WKL0Ue-x9C0Ab5dlbGX&_nc_ht=scontent.fsof8-1.fna&oh=00_AfBFjpOstWev93jV0N4bbinwWIkC6LZGlSo9qQbawqpqyw&oe=661950D9",
				Price = 50.00m,
				ProductCategoryId = CarvingCategory.Id,
				CreatorId = Creator.Id
			};

			SecondProduct = new Product()
			{
				Id = 2,
				Title = "Handmade wood carving of an Owl in a hollow.",
				Description = "I also used searing and some pyrography to make it.",
				ImageUrl = "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/411834478_895715185897529_2597910820054918143_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=5f2048&_nc_ohc=IsEJHhi4D9QAb7ayrT8&_nc_ht=scontent.fsof8-1.fna&oh=00_AfALkCPjPaMx4OV1wEVUKutMsZP731BV-LHCtlU_TQgLqw&oe=66197E58",
				Price =75.00M,
				ProductCategoryId = CarvingCategory.Id,
				CreatorId = Creator.Id
			};
		}
		private void SeedCourseCategories()
		{
			PaintingCourse = new CourseCategory()
			{
				Id = 1,
				Name = "Painting Course"
			};

			CarvingCourse = new CourseCategory()
			{
				Id = 2,
				Name = "Carving Course"
			};

			SculpturingCourse = new CourseCategory()
			{
				Id = 3,
				Name = "Sculpturing Course"
			};
		}
		private void SeedCourses()
		{
			FirstCourse = new Course()
			{
				Id = 1,
				Title = "Working with common tools",
				Details = "Introduction in the world of creatng.",
				CreatorId = CreatorUser.Id,
				Location="Veliko Tarnovo",
				CourseCategoryId= CarvingCategory.Id,
				Duration=3
			};
			SecondCourse = new Course()
			{
				Id = 2,
				Title = "Working with advanced tools",
				Details = "Start dealing with toold which need more experience in this sphere of creating.",
				CreatorId = CreatorUser.Id,
				Location = "Veliko Tarnovo",
				CourseCategoryId = CarvingCategory.Id,
				Duration = 6
			};
		}

		private void SeedLections()
		{
			WorkingWithHammer = new Lection()
			{
				Id = 1,
				Topic = "Working with hammer",
				Details = "Do some creations only by using hammer",
				CourseId=FirstCourse.Id
			};
			WorkingWithEngraver = new Lection()
			{
				Id = 2,
				Topic = "Working with engraver",
				Details = "Do some creations only by using engraver",
				CourseId = SecondCourse.Id
			};
		}
	}
}