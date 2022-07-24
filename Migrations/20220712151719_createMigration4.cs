using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Web_Api.Migrations
{
    public partial class createMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "product",
                table: "Orders",
                newName: "OrderedBy");

            migrationBuilder.CreateTable(
                name: "OrderList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderList");

            migrationBuilder.RenameColumn(
                name: "OrderedBy",
                table: "Orders",
                newName: "product");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "totalPrice",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
