using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermarketAPI.Migrations
{
    public partial class SeedingItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "CostPrice", "Name", "Quantity", "SellingPrice" },
                values: new object[] { new Guid("257ce398-2ef9-4609-8ca0-ec084ce71ffa"), "Beverages", 200, "Peak Milk", 65, 300 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "CostPrice", "Name", "Quantity", "SellingPrice" },
                values: new object[] { new Guid("ca1b67e7-8bd2-402b-b2c7-5b87816bd6f1"), "Yeast", 250, "Yoghurts", 34, 360 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("257ce398-2ef9-4609-8ca0-ec084ce71ffa"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ca1b67e7-8bd2-402b-b2c7-5b87816bd6f1"));
        }
    }
}
