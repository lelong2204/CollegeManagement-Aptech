using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeManagement.Migrations
{
    public partial class JoinStudentFacultyToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Admission",
                table: "Student",
                newName: "UserID");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Faculty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserID",
                table: "Student",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_UserID",
                table: "Faculty",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_User_UserID",
                table: "Faculty",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_UserID",
                table: "Student",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculty_User_UserID",
                table: "Faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_UserID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_UserID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Faculty_UserID",
                table: "Faculty");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Faculty");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Student",
                newName: "Admission");
        }
    }
}
