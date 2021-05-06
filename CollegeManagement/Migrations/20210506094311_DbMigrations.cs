using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeManagement.Migrations
{
    public partial class DbMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactSupport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Infomation = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Question = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactSupport", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Info = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DeanID = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Info = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContentBody",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImgDes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContentID = table.Column<int>(type: "int", nullable: true),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentBody", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContentBody_Content_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Content",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evaluate = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Focus = table.Column<byte>(type: "tinyint", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Info = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ExperienceYear = table.Column<int>(type: "int", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Faculty_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Admission = table.Column<int>(type: "int", nullable: true),
                    TestScore = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubject",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseSubject_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubject_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubject_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultySubject",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultySubject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FacultySubject_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultySubject_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Marks_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Marks_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentBody_ContentID",
                table: "ContentBody",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_CourseID",
                table: "CourseSubject",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_FacultyID",
                table: "CourseSubject",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_SubjectID",
                table: "CourseSubject",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_DepartmentID",
                table: "Faculty",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultySubject_FacultyID",
                table: "FacultySubject",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultySubject_SubjectID",
                table: "FacultySubject",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentID",
                table: "Marks",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_SubjectID",
                table: "Marks",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CourseID",
                table: "Student",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactSupport");

            migrationBuilder.DropTable(
                name: "ContentBody");

            migrationBuilder.DropTable(
                name: "CourseSubject");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "FacultySubject");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
