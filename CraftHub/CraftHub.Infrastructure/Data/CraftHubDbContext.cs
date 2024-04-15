using CraftHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CraftHub.Data
{
	public class CraftHubDbContext : IdentityDbContext
	{
		public CraftHubDbContext(DbContextOptions<CraftHubDbContext> options)
			: base(options)
		{
		}

		public DbSet<Course> Courses { get; set; } = null!;
		public DbSet<CourseParticipant> CoursesParticipant { get; set;} = null!;
		public DbSet<CourseCategory> CourseCategories { get; set; } = null!;
		public DbSet<Creator> Creators { get; set; } = null!;
		public DbSet<Lection> Lections { get; set; } = null!;
		public DbSet<Product> Products { get; set; }=null!;
		public DbSet<ProductCategory> ProductCategories { get;set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<CourseParticipant>()
				.HasKey(cp => new{cp.ParticipantId, cp.CourseId});

			builder.Entity<CourseParticipant>()
			   .HasOne(s => s.Course)
			   .WithMany(s => s.CourseParticipants)
			   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Cart>()
                .HasKey(c => new { c.ProductId, c.BuyerId});


            builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new CreatorConfiguration());
			builder.ApplyConfiguration(new ProductCategoryConfiguration());
			builder.ApplyConfiguration(new ProductConfiguration());

			builder.ApplyConfiguration(new CourseCategoryConfiguration());
			builder.ApplyConfiguration(new CourseConfiguration());
			builder.ApplyConfiguration(new LectionConfiguration());
			builder.ApplyConfiguration(new CourseParticipantConfiguration());

			base.OnModelCreating(builder);
		}
		public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
		{
			public void Configure(EntityTypeBuilder<IdentityUser> builder)
			{
				var data = new SeedData();
				builder.HasData(new IdentityUser[] { data.CreatorUser, data.GuestUser });
			}
		}
		public class CreatorConfiguration : IEntityTypeConfiguration<Creator>
		{
			public void Configure(EntityTypeBuilder<Creator> builder)
			{
				var data = new SeedData();
				builder.HasData(new Creator[] { data.Creator });
			}
		}
		public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
		{
			public void Configure(EntityTypeBuilder<ProductCategory> builder)
			{
				var data = new SeedData();
				builder.HasData(new ProductCategory[] { data.CarvingCategory, data.PaintingCategory, data.SculpturingCategory });
			}
		}
		public class ProductConfiguration : IEntityTypeConfiguration<Product>
		{
			public void Configure(EntityTypeBuilder<Product> builder)
			{
				builder
					.HasOne(h => h.ProductCategory)
					.WithMany(c => c.Products)
					.HasForeignKey(h => h.ProductCategoryId)
					.OnDelete(DeleteBehavior.Restrict);

				builder
					.HasOne(h => h.Creator)
					.WithMany(c=>c.Products)
					.HasForeignKey(h => h.CreatorId)
					.OnDelete(DeleteBehavior.Restrict);

				var data = new SeedData();
				builder.HasData(new Product[] { data.FirstProduct, data.SecondProduct});
			}
		}
		public class CourseCategoryConfiguration : IEntityTypeConfiguration<CourseCategory>
		{
			public void Configure(EntityTypeBuilder<CourseCategory> builder)
			{
				var data = new SeedData();
				builder.HasData(new CourseCategory[] { data.CarvingCourse, data.PaintingCourse, data.SculpturingCourse });
			}
		}
		public class CourseConfiguration : IEntityTypeConfiguration<Course>
		{
			public void Configure(EntityTypeBuilder<Course> builder)
			{
				builder
					.HasOne(h => h.CourseCategory)
					.WithMany(c => c.Courses)
					.HasForeignKey(h => h.CourseCategoryId)
					.OnDelete(DeleteBehavior.Restrict);

				builder
					.HasOne(h => h.Organizer)
					.WithMany(c=>c.Courses)
					.HasForeignKey(h => h.CreatorId)
					.OnDelete(DeleteBehavior.Restrict);

				var data = new SeedData();
				builder.HasData(new Course[] { data.FirstCourse, data.SecondCourse });
			}
		}
		public class LectionConfiguration : IEntityTypeConfiguration<Lection>
		{
			public void Configure(EntityTypeBuilder<Lection> builder)
			{
				builder
					.HasOne(h => h.Course)
					.WithMany(c => c.Lections)
					.HasForeignKey(h => h.CourseId)
					.OnDelete(DeleteBehavior.Restrict);

				var data = new SeedData();
				builder.HasData(new Lection[] { data.WorkingWithEngraver, data.WorkingWithHammer });
			}
		}
		public class CourseParticipantConfiguration : IEntityTypeConfiguration<CourseParticipant>
		{
			public void Configure(EntityTypeBuilder<CourseParticipant> builder)
			{

				var data = new SeedData();
				builder.HasData(new CourseParticipant[] { data.FirstCourseParticipant, data.SecondCourseParticipant });
			}
		}
	}
}