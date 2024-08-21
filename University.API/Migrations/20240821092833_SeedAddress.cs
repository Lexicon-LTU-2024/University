using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace University.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Street", "StudentId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Stockholm", "Kungsgatan", 1, "123" },
                    { 2, "Stockholm", "Kungsgatan", 2, "123" },
                    { 3, "Stockholm", "Kungsgatan", 3, "123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
