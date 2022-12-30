using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductConfigurator.Core.Database.Migrations.Application
{
    /// <inheritdoc />
    public partial class AddShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Users",
                newName: "ShopId");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShopId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Users",
                newName: "TenantId");
        }
    }
}
