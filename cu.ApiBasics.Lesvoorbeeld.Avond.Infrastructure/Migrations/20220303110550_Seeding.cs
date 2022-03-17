using Microsoft.EntityFrameworkCore.Migrations;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Laptops" },
                    { 2, "PC's" },
                    { 3, "Phones" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Basic" },
                    { 2, "Luxury" },
                    { 3, "Student" },
                    { 4, "Family" },
                    { 5, "Office" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 3, 1, null, "Dell Latitude", 1456.23m },
                    { 5, 1, null, "IBook 7", 2456.00m },
                    { 4, 2, null, "Dell Desktop", 856.3m },
                    { 1, 3, null, "Samsung L7", 456.23m },
                    { 2, 3, null, "Redmi Note7", 325.13m },
                    { 6, 3, null, "Iphone12", 958.23m }
                });

            migrationBuilder.InsertData(
                table: "ProductProperty",
                columns: new[] { "ProductsId", "PropertiesId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 3, 3 },
                    { 5, 1 },
                    { 5, 3 },
                    { 4, 1 },
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 6, 1 },
                    { 6, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumns: new[] { "ProductsId", "PropertiesId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5);

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

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
