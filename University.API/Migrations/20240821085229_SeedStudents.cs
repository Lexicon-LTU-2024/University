using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace University.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Avatar", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "123", "Kalle1", "Anka" },
                    { 2, "123", "Kalle2", "Anka" },
                    { 3, "123", "Kalle3", "Anka" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
