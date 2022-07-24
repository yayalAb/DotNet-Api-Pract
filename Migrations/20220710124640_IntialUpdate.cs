using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Web_Api.Migrations
{
    public partial class IntialUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quality",
                table: "Products",
                newName: "ProductQuality");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "ExDate",
                table: "Products",
                newName: "ProductCategory");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductQuality",
                table: "Products",
                newName: "Quality");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductCategory",
                table: "Products",
                newName: "ExDate");
        }
    }
}
