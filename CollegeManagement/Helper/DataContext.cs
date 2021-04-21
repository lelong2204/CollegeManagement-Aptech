using CollegeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Helper
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<ContactSupport> ContactSupports { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<FacultySubject> FacultySubjects { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeImage> HomeImages { get; set; }
        public DbSet<Marks> Markss { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<SubjectCourse> SubjectCourses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<ContactSupport>().ToTable("ContactSupport");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<CourseImage>().ToTable("CourseImage");
            modelBuilder.Entity<Facility>().ToTable("Facility");
            modelBuilder.Entity<Faculty>().ToTable("Faculty");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<FacultySubject>().ToTable("FacultySubject");
            modelBuilder.Entity<Home>().ToTable("Home");
            modelBuilder.Entity<HomeImage>().ToTable("HomeImage");
            modelBuilder.Entity<Marks>().ToTable("Marks");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse");
            modelBuilder.Entity<SubjectCourse>().ToTable("SubjectCourse");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
