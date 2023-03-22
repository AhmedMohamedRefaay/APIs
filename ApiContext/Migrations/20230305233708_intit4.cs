using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiContext.Migrations
{
    /// <inheritdoc />
    public partial class intit4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "carrierId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carrier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrier", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_carrierId",
                table: "Products",
                column: "carrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carrier_carrierId",
                table: "Products",
                column: "carrierId",
                principalTable: "Carrier",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carrier_carrierId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Carrier");

            migrationBuilder.DropIndex(
                name: "IX_Products_carrierId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "carrierId",
                table: "Products");
        }
    }
}
