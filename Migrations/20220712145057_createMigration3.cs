using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Web_Api.Migrations
{
    public partial class createMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "End",
                table: "Orders",
                newName: "Destination");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "totalPrice",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Orders",
                newName: "End");
        }
    }
}
