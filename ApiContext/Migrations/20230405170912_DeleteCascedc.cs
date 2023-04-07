using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiContext.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCascedc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_orderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_orderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_orderId",
                table: "Products",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_orderId",
                table: "Products",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
