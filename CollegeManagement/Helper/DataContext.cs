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
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<FacultySubject> FacultySubjects { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentBody> ContentBodys { get; set; }
        public DbSet<Marks> Markses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<ContactSupport>().ToTable("ContactSupport");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<CourseSubject>().ToTable("CourseSubject");
            modelBuilder.Entity<Facility>().ToTable("Facility");
            modelBuilder.Entity<Faculty>().ToTable("Faculty");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<FacultySubject>().ToTable("FacultySubject");
            modelBuilder.Entity<Content>().ToTable("Content");
            modelBuilder.Entity<ContentBody>().ToTable("ContentBody");
            modelBuilder.Entity<Marks>().ToTable("Marks");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
