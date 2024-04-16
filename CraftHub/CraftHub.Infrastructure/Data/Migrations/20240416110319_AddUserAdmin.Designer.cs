﻿// <auto-generated />
using System;
using CraftHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CraftHub.Data.Migrations
{
    [DbContext(typeof(CraftHubDbContext))]
    [Migration("20240416110319_AddUserAdmin")]
    partial class AddUserAdmin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Cart", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasComment("Identifier of added product.");

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Identifier of the buyer who will add the product in the cart.");

                    b.HasKey("ProductId", "BuyerId");

                    b.HasIndex("BuyerId");

                    b.ToTable("Carts");

                    b.HasComment("This is the entity which will save people's products in their shopping carts.");
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("This is the id, representing this course.");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseCategoryId")
                        .HasColumnType("int")
                        .HasComment("Id of the course category.");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasComment("Id of the creator who is the creator.");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("More details about the course.");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasComment("Duration of the course in months. How long it will take?");

                    b.Property<string>("Lecturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("This is the person who will lecture the course.");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("This string contains the location of the course.");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("This is string which contains the topic of the course.");

                    b.HasKey("Id");

                    b.HasIndex("CourseCategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Courses");

                    b.HasComment("Class which holds all information about the course.");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseCategoryId = 2,
                            CreatorId = 1,
                            Details = "Introduction in the world of creatng.",
                            Duration = 3,
                            Lecturer = "",
                            Location = "Veliko Tarnovo",
                            Title = "Working with common tools"
                        },
                        new
                        {
                            Id = 2,
                            CourseCategoryId = 2,
                            CreatorId = 1,
                            Details = "Start dealing with toold which need more experience in this sphere of creating.",
                            Duration = 6,
                            Lecturer = "",
                            Location = "Veliko Tarnovo",
                            Title = "Working with advanced tools"
                        });
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.CourseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identifier of the course category.");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the category.");

                    b.HasKey("Id");

                    b.ToTable("CourseCategories");

                    b.HasComment("This class contains information about category of the course.");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Carving Course"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Painting Course"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sculpturing Course"
                        });
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.CourseParticipant", b =>
                {
                    b.Property<string>("ParticipantId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Identifier of the participant who will go on the course.");

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasComment("Identifier of current course.");

                    b.HasKey("ParticipantId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CoursesParticipant");

                    b.HasComment("This is entity which makes possible many to many relation between classes.");

                    b.HasData(
                        new
                        {
                            ParticipantId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            CourseId = 1
                        },
                        new
                        {
                            ParticipantId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            CourseId = 2
                        });
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Creator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Special identifier for every creator");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("String for the name of the business.");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("String for the user's email.");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("String for the creator's name.");

                    b.Property<string>("MoreInformation")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("String which contains more information about the creator's work");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("String for the creator's phone number.");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("String for the creator's website");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Creators");

                    b.HasComment("This is entity which contains all the information about the creator");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusinessName = "Rezbart",
                            Email = "creator@mail.com",
                            FullName = "Daniel Atanasov",
                            MoreInformation = "",
                            PhoneNumber = "+359888888888",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082",
                            Website = "https://www.facebook.com/rezbart.bg"
                        },
                        new
                        {
                            Id = 14,
                            BusinessName = "CraftHub",
                            Email = "admin@mail.com",
                            FullName = "Stanislav Trendafilov",
                            MoreInformation = "",
                            PhoneNumber = "+359888789000",
                            UserId = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                            Website = "https://github.com/Stanislav-Trendafilov/CraftHub/tree/master/CraftHub"
                        });
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Lection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("This is the id, representing this lection.");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasComment("Id of the course which contains this lection.");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2")
                        .HasComment("The date of the lection.");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("More details about the lection.");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("This is te topic of the lection.");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lections");

                    b.HasComment("Class which holds all information about the lection in the course.");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            DateAndTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Do some creations only by using engraver",
                            Topic = "Working with engraver"
                        },
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            DateAndTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Do some creations only by using hammer",
                            Topic = "Working with hammer"
                        });
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasComment("Identifier which saves the id of the creator.");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Text for the product's description.");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("ImageURl for the image of the product.");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the product(floating-point number).");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int")
                        .HasComment("Identifier which saves the id of the category.");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("String for the product's title.");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");

                    b.HasComment("Entity which contains all the information about one product.");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatorId = 1,
                            Description = "Light restoration of an axe with pyrographing Dulot's mark.",
                            ImageUrl = "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/434946900_973518331450547_6779376460553241297_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=5f2048&_nc_ohc=WKL0Ue-x9C0Ab5dlbGX&_nc_ht=scontent.fsof8-1.fna&oh=00_AfBFjpOstWev93jV0N4bbinwWIkC6LZGlSo9qQbawqpqyw&oe=661950D9",
                            Price = 50.00m,
                            ProductCategoryId = 2,
                            Title = "Restavrated Axe"
                        },
                        new
                        {
                            Id = 2,
                            CreatorId = 1,
                            Description = "I also used searing and some pyrography to make it.",
                            ImageUrl = "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/411834478_895715185897529_2597910820054918143_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=5f2048&_nc_ohc=IsEJHhi4D9QAb7ayrT8&_nc_ht=scontent.fsof8-1.fna&oh=00_AfALkCPjPaMx4OV1wEVUKutMsZP731BV-LHCtlU_TQgLqw&oe=66197E58",
                            Price = 75.00m,
                            ProductCategoryId = 2,
                            Title = "Handmade wood carving of an Owl in a hollow."
                        });
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("String for name of the category");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasComment("This entity contains all the information about categories of the products");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Carving"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Painting"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sculpturing"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7adae483-3808-4dda-864b-2cf3186a16e2",
                            Email = "creator@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "creator@mail.com",
                            NormalizedUserName = "creator@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEEGgrU6jdWs1GhUmqdDR34+XnoaF6dfVUVS1wCVKc1UcD3ZvhShLbUo95Q9RKbBOZg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cba458a1-f9df-44ee-81ae-d1ef0232495b",
                            TwoFactorEnabled = false,
                            UserName = "creator@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ad33e221-00e6-4da5-87c6-7023ace48d02",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEMWkJGTv8bwJOHO3+KlnPof9vE7FhrkUpaJc1oV55n/VSz28rhNsOBmI9KU5mfF9fA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "83ed9c39-43de-4f2d-9afc-dbdc6331917c",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        },
                        new
                        {
                            Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5127ba2e-8f28-4ddd-9c06-0941ea2f3c90",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEA3sqhDM90wDXe1CV8ubQqC4qa85L+BOeebmJuxZOrdDWfZDOpZge5BhoICbI4NKsA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5ca41224-5f1e-4e30-b226-7b42be0740f9",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Cart", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CraftHub.Infrastructure.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Course", b =>
                {
                    b.HasOne("CraftHub.Infrastructure.Data.Models.CourseCategory", "CourseCategory")
                        .WithMany("Courses")
                        .HasForeignKey("CourseCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CraftHub.Infrastructure.Data.Models.Creator", "Organizer")
                        .WithMany("Courses")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CourseCategory");

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.CourseParticipant", b =>
                {
                    b.HasOne("CraftHub.Infrastructure.Data.Models.Course", "Course")
                        .WithMany("CourseParticipants")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Creator", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Lection", b =>
                {
                    b.HasOne("CraftHub.Infrastructure.Data.Models.Course", "Course")
                        .WithMany("Lections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Product", b =>
                {
                    b.HasOne("CraftHub.Infrastructure.Data.Models.Creator", "Creator")
                        .WithMany("Products")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CraftHub.Infrastructure.Data.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Course", b =>
                {
                    b.Navigation("CourseParticipants");

                    b.Navigation("Lections");
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.CourseCategory", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.Creator", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("CraftHub.Infrastructure.Data.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
