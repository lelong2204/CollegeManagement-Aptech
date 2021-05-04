using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeManagement.Migrations
{
    public partial class NewDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxStudentPerCourse",
                table: "Course");

            migrationBuilder.AddColumn<int>(
                name: "MaxStudentPerClass",
                table: "Class",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxStudentPerClass",
                table: "Class");

            migrationBuilder.AddColumn<int>(
                name: "MaxStudentPerCourse",
                table: "Course",
                type: "int",
                nullable: true);
        }
    }
}
