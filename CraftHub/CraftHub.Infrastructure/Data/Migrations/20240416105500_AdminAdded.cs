using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftHub.Data.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6755e212-82f6-4540-90b3-76aa11cd01a1", "AQAAAAEAACcQAAAAEBLXpUTJKY6IfEEb+nG3lyDGfP+yi8NxhPEkIH4GEHlMjF1Uyp3GM34/Izo+bgibFA==", "7616ca48-6a31-4255-9d94-478949748741" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f6e55f4-4d68-466f-a090-357581542714", "AQAAAAEAACcQAAAAEJR0MCMDnkI6cipTAwnZOx/eteaQFaey5bFb7AYD9Lm5VoR6hBOVYek+PmPp9M8oVQ==", "7ad1cfdd-0ca8-47e1-8802-e5b604127a88" });
        }
    }
}
