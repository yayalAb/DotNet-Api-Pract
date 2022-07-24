using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Web_Api.Migrations
{
    public partial class OrderDriverRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Driver",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DriverId",
                table: "Orders",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drivers_DriverId",
                table: "Orders",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drivers_DriverId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DriverId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Driver",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
