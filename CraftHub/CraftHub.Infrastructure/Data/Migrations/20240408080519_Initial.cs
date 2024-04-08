using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftHub.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the course category.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the category.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.Id);
                },
                comment: "This class contains information about category of the course.");

            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Special identifier for every creator"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "String for the creator's phone number."),
                    FullName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "String for the creator's name."),
                    BusinessName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "String for the name of the business."),
                    MoreInformation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "String which contains more information about the creator's work"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "String for the user's email."),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "String for the creator's website"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "This is entity which contains all the information about the creator");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "String for name of the category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                },
                comment: "This entity contains all the information about categories of the products");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "This is the id, representing this course.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "This is string which contains the topic of the course."),
                    Lecturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "This is the person who will lecture the course."),
                    Details = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "More details about the course."),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the creator who is the creator."),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "This string contains the location of the course."),
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Id of the course category."),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "Duration of the course in months. How long it will take?"),
                    CreatorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Creators_CreatorId1",
                        column: x => x.CreatorId1,
                        principalTable: "Creators",
                        principalColumn: "Id");
                },
                comment: "Class which holds all information about the course.");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "String for the product's title."),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Text for the product's description."),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product(floating-point number)."),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "ImageURl for the image of the product."),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Identifier which saves the id of the category."),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Identifier which saves the id of the creator."),
                    CreatorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Creators_CreatorId1",
                        column: x => x.CreatorId1,
                        principalTable: "Creators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Entity which contains all the information about one product.");

            migrationBuilder.CreateTable(
                name: "CoursesParticipant",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of current course."),
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Identifier of the participant who will go on the course.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesParticipant", x => new { x.ParticipantId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CoursesParticipant_AspNetUsers_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesParticipant_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "This is entity which makes possible many to many relation between classes.");

            migrationBuilder.CreateTable(
                name: "Lections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "This is the id, representing this lection.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "This is te topic of the lection."),
                    Details = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "More details about the lection."),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date of the lection."),
                    CourseId = table.Column<int>(type: "int", nullable: false, comment: "Id of the course which contains this lection.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Class which holds all information about the lection in the course.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "3469687d-b723-4854-9ac7-26f5011fb50a", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAENlv/MMFUyOtkeF+5m7fKRFaf7BKyJ6fLfqyWG3UDOG9beNEJhYCEgM3SwzfHwe0oA==", null, false, "53422bbe-27b1-41c1-a479-2716aea2d708", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "a440261c-acf3-49c0-a403-c22d59a37759", "creator@mail.com", false, false, null, "creator@mail.com", "creator@mail.com", "AQAAAAEAACcQAAAAEJK8dDSlJRiV9Ri7RKIoMX1afgt4n2lUWqPRtvlcHS3ciaMRjSsV3J8uJlNTVF6ZXg==", null, false, "0f9a734a-b601-4c86-9dc3-922a636bd8e9", false, "creator@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Painting Course" },
                    { 2, "Carving Course" },
                    { 3, "Sculpturing Course" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Painting" },
                    { 2, "Carving" },
                    { 3, "Sculpturing" }
                });

            migrationBuilder.InsertData(
                table: "Creators",
                columns: new[] { "Id", "BusinessName", "Email", "FullName", "MoreInformation", "PhoneNumber", "UserId", "Website" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", "Rezbart", "creator@mail.com", "Daniel Atanasov", "", "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082", "https://www.facebook.com/rezbart.bg" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCategoryId", "CreatorId", "CreatorId1", "Details", "Duration", "Lecturer", "Location", "Title" },
                values: new object[,]
                {
                    { 1, 2, "dea12856-c198-4129-b3f3-b893d8395082", null, "Introduction in the world of creatng.", 3, "", "Veliko Tarnovo", "Working with common tools" },
                    { 2, 2, "dea12856-c198-4129-b3f3-b893d8395082", null, "Start dealing with toold which need more experience in this sphere of creating.", 6, "", "Veliko Tarnovo", "Working with advanced tools" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatorId", "CreatorId1", "Description", "ImageUrl", "Price", "ProductCategoryId", "Title" },
                values: new object[,]
                {
                    { 1, "dea12856-c198-4129-b3f3-b893d8395082", null, "Light restoration of an axe with pyrographing Dulot's mark.", "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/434946900_973518331450547_6779376460553241297_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=5f2048&_nc_ohc=WKL0Ue-x9C0Ab5dlbGX&_nc_ht=scontent.fsof8-1.fna&oh=00_AfBFjpOstWev93jV0N4bbinwWIkC6LZGlSo9qQbawqpqyw&oe=661950D9", 50.00m, 2, "Restavrated Axe" },
                    { 2, "dea12856-c198-4129-b3f3-b893d8395082", null, "I also used searing and some pyrography to make it.", "https://scontent.fsof8-1.fna.fbcdn.net/v/t39.30808-6/411834478_895715185897529_2597910820054918143_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=5f2048&_nc_ohc=IsEJHhi4D9QAb7ayrT8&_nc_ht=scontent.fsof8-1.fna&oh=00_AfALkCPjPaMx4OV1wEVUKutMsZP731BV-LHCtlU_TQgLqw&oe=66197E58", 75.00m, 2, "Handmade wood carving of an Owl in a hollow." }
                });

            migrationBuilder.InsertData(
                table: "Lections",
                columns: new[] { "Id", "CourseId", "DateAndTime", "Details", "Topic" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do some creations only by using hammer", "Working with hammer" });

            migrationBuilder.InsertData(
                table: "Lections",
                columns: new[] { "Id", "CourseId", "DateAndTime", "Details", "Topic" },
                values: new object[] { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do some creations only by using engraver", "Working with engraver" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCategoryId",
                table: "Courses",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorId1",
                table: "Courses",
                column: "CreatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesParticipant_CourseId",
                table: "CoursesParticipant",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Creators_PhoneNumber",
                table: "Creators",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creators_UserId",
                table: "Creators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lections_CourseId",
                table: "Lections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatorId",
                table: "Products",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatorId1",
                table: "Products",
                column: "CreatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesParticipant");

            migrationBuilder.DropTable(
                name: "Lections");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "Creators");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
