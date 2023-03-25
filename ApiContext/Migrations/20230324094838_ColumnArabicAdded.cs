using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiContext.Migrations
{
    /// <inheritdoc />
    public partial class ColumnArabicAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ContactDetails_ContactDetailsId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ContactDetailsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ContactDetailsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Fname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "DiscriptionArabic",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameArabic",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameArabic",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscriptionArabic",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameArabic",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameArabic",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailsId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactDetails_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContactDetailsId",
                table: "Orders",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_userId",
                table: "ContactDetails",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ContactDetails_ContactDetailsId",
                table: "Orders",
                column: "ContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "Id");
        }
    }
}
