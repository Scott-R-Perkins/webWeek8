using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webWeek8.Data.Migrations.InitialMigration
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course_1",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_1", x => x.courseId);
                });

            migrationBuilder.CreateTable(
                name: "Student_1",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_1", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_Student_1_Course_1_courseId",
                        column: x => x.courseId,
                        principalTable: "Course_1",
                        principalColumn: "courseId");
                });

            migrationBuilder.CreateTable(
                name: "Tutor_1",
                columns: table => new
                {
                    tutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor_1", x => x.tutorId);
                    table.ForeignKey(
                        name: "FK_Tutor_1_Course_1_courseId",
                        column: x => x.courseId,
                        principalTable: "Course_1",
                        principalColumn: "courseId");
                });

            migrationBuilder.InsertData(
                table: "Course_1",
                columns: new[] { "courseId", "name" },
                values: new object[,]
                {
                    { 701, "Project" },
                    { 710, "Web applications" },
                    { 721, "Software engineering" }
                });

            migrationBuilder.InsertData(
                table: "Student_1",
                columns: new[] { "studentId", "courseId", "name" },
                values: new object[,]
                {
                    { 1, null, "Scott" },
                    { 2, null, "Bob" },
                    { 3, null, "James" }
                });

            migrationBuilder.InsertData(
                table: "Tutor_1",
                columns: new[] { "tutorId", "courseId", "name" },
                values: new object[,]
                {
                    { 1, null, "Josh" },
                    { 2, null, "Oliver" },
                    { 3, null, "Abdul" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_1_courseId",
                table: "Student_1",
                column: "courseId",
                unique: true,
                filter: "[courseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tutor_1_courseId",
                table: "Tutor_1",
                column: "courseId",
                unique: true,
                filter: "[courseId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_1");

            migrationBuilder.DropTable(
                name: "Tutor_1");

            migrationBuilder.DropTable(
                name: "Course_1");
        }
    }
}
