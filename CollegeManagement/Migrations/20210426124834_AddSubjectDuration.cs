using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeManagement.Migrations
{
    public partial class AddSubjectDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvancedDuration",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BasicDuration",
                table: "Subject",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvancedDuration",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "BasicDuration",
                table: "Subject");
        }
    }
}
