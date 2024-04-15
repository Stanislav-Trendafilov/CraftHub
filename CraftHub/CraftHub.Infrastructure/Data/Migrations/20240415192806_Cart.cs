using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftHub.Data.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of added product."),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Identifier of the buyer who will add the product in the cart.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.ProductId, x.BuyerId });
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "This is the entity which will save people's products in their shopping carts.");

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

            migrationBuilder.CreateIndex(
                name: "IX_Carts_BuyerId",
                table: "Carts",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

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
    }
}
