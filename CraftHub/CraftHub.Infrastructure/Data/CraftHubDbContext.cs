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

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<CourseParticipant>()
				.HasKey(cp => new{cp.ParticipantId, cp.CourseId});

			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new CreatorConfiguration());
			builder.ApplyConfiguration(new ProductCategoryConfiguration());
			builder.ApplyConfiguration(new ProductConfiguration());
			
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
					.WithMany()
					.HasForeignKey(h => h.CreatorId)
					.OnDelete(DeleteBehavior.Restrict);

				var data = new SeedData();
				builder.HasData(new Product[] { data.FirstProduct, data.SecondProduct});
			}
		}
		


	}
}