using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.API.Migrations
{
    /// <inheritdoc />
    public partial class Books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrOfPages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCourse",
                columns: table => new
                {
                    CourseBooksId = table.Column<int>(type: "int", nullable: false),
                    UsedByCoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCourse", x => new { x.CourseBooksId, x.UsedByCoursesId });
                    table.ForeignKey(
                        name: "FK_BookCourse_Book_CourseBooksId",
                        column: x => x.CourseBooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCourse_Course_UsedByCoursesId",
                        column: x => x.UsedByCoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCourse_UsedByCoursesId",
                table: "BookCourse",
                column: "UsedByCoursesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCourse");

            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
