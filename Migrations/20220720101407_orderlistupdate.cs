using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Web_Api.Migrations
{
    public partial class orderlistupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product",
                table: "OrderList");

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "OrderList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "OrderList");

            migrationBuilder.AddColumn<string>(
                name: "product",
                table: "OrderList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
