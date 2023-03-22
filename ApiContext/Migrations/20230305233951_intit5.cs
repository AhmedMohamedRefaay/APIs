using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiContext.Migrations
{
    /// <inheritdoc />
    public partial class intit5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carrier_carrierId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrier",
                table: "Carrier");

            migrationBuilder.RenameTable(
                name: "Carrier",
                newName: "Carriers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carriers",
                table: "Carriers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carriers_carrierId",
                table: "Products",
                column: "carrierId",
                principalTable: "Carriers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carriers_carrierId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carriers",
                table: "Carriers");

            migrationBuilder.RenameTable(
                name: "Carriers",
                newName: "Carrier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrier",
                table: "Carrier",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carrier_carrierId",
                table: "Products",
                column: "carrierId",
                principalTable: "Carrier",
                principalColumn: "Id");
        }
    }
}
