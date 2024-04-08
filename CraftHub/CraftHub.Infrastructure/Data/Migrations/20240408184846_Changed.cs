using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftHub.Data.Migrations
{
    public partial class Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Creators_CreatorId1",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Creators_CreatorId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatorId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CreatorId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bf76259-0fde-4720-9ec5-6148a6663954", "AQAAAAEAACcQAAAAEDGQIJcE218YFY3rSSocJjo8ARRiQ3QqQjA+3/6twch9kX8ZGIoql+PQwj/G26rJUQ==", "28cdff73-9e99-42b2-b502-6dc32aee6231" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aa1b37e-b8e8-48ac-8752-2933f62b8d53", "AQAAAAEAACcQAAAAEIat8aQ1AJzfne2hDf23X24F9pmPWsqyhV1kwIc9e1c5rN0Sp7zgTLV70/jJIxngbA==", "764023c0-0476-4418-b61c-d5fff0265e9d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId1",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7975fa86-4225-431f-a86d-2704aeec9a23", "AQAAAAEAACcQAAAAELozyQCg/ZbTNqIwDcAAbfgwcLPlmuRP4XnYOok8b30TajpSu/QYGIPKRWiyk59/Dg==", "b4acfcde-5a61-45de-bfe9-eb059dc007a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1852579a-5dba-426e-a3a2-8ba76f4e4a23", "AQAAAAEAACcQAAAAED28p/vuelbetxMub0lDa7oqyF3iOj+agP0T3bB8Ya/iDFIB0d/i7cc4797dV0Csqw==", "6a0e794d-9966-48a5-b8c0-856fe859f7cd" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatorId1",
                table: "Products",
                column: "CreatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorId1",
                table: "Courses",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Creators_CreatorId1",
                table: "Courses",
                column: "CreatorId1",
                principalTable: "Creators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Creators_CreatorId1",
                table: "Products",
                column: "CreatorId1",
                principalTable: "Creators",
                principalColumn: "Id");
        }
    }
}
