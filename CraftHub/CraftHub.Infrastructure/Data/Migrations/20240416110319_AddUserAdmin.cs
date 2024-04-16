using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftHub.Data.Migrations
{
    public partial class AddUserAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad33e221-00e6-4da5-87c6-7023ace48d02", "AQAAAAEAACcQAAAAEMWkJGTv8bwJOHO3+KlnPof9vE7FhrkUpaJc1oV55n/VSz28rhNsOBmI9KU5mfF9fA==", "83ed9c39-43de-4f2d-9afc-dbdc6331917c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7adae483-3808-4dda-864b-2cf3186a16e2", "AQAAAAEAACcQAAAAEEGgrU6jdWs1GhUmqdDR34+XnoaF6dfVUVS1wCVKc1UcD3ZvhShLbUo95Q9RKbBOZg==", "cba458a1-f9df-44ee-81ae-d1ef0232495b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "5127ba2e-8f28-4ddd-9c06-0941ea2f3c90", "admin@mail.com", false, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEA3sqhDM90wDXe1CV8ubQqC4qa85L+BOeebmJuxZOrdDWfZDOpZge5BhoICbI4NKsA==", null, false, "5ca41224-5f1e-4e30-b226-7b42be0740f9", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Creators",
                columns: new[] { "Id", "BusinessName", "Email", "FullName", "MoreInformation", "PhoneNumber", "UserId", "Website" },
                values: new object[] { 14, "CraftHub", "admin@mail.com", "Stanislav Trendafilov", "", "+359888789000", "bcb4f072-ecca-43c9-ab26-c060c6f364e4", "https://github.com/Stanislav-Trendafilov/CraftHub/tree/master/CraftHub" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Creators",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e910bd01-1a42-4413-bd78-1249588a13d3", "AQAAAAEAACcQAAAAEPzFEIajmpu0G3dyZnfpyraOqW22LSjr67A79Z/+6Oe2gBNoQSdCyKJP3veXRLVQyw==", "112f1ee8-561f-4e29-9c5e-7a93c9a5fa3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "291ee478-030c-476b-946f-3597b4834ec9", "AQAAAAEAACcQAAAAEJHKGobuQwUdVPn1FbCoBqktDgXLky4orKr53YuNadvKwscQf4XxX18GYdtYyr1O3Q==", "3dfe7b50-da2f-455f-a9ec-6c508291ae55" });
        }
    }
}
