using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeManagement.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntryPoint",
                table: "Course",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryPoint",
                table: "Course");
        }
    }
}
