using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_PROJECT.Migrations
{
    /// <inheritdoc />
    public partial class seeding_products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "Latest iPhone model", null, "iPhone 13", 999.99m, 0, 0.0 },
                    { 2, 1, "Flagship Samsung phone", null, "Samsung Galaxy S21", 899.99m, 0, 0.0 },
                    { 3, 2, "High-end tablet from Apple", null, "iPad Pro", 799.99m, 0, 0.0 },
                    { 4, 2, "Versatile 2-in-1 device", null, "Microsoft Surface Pro", 999.99m, 0, 0.0 },
                    { 5, 3, "Powerful laptop from Apple", null, "MacBook Pro", 1299.99m, 0, 0.0 },
                    { 6, 3, "Compact and powerful laptop", null, "Dell XPS 13", 1099.99m, 0, 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
