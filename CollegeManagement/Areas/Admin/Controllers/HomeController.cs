using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using CollegeManagement.DTO.Dashboard;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var res = new DashboardDTO();

            res.CourseStudentNumber = await (from c in _context.Courses
                                       join s in _context.Students on c.ID equals s.CourseID
                                       into m
                                       from s in m.DefaultIfEmpty()
                                       group s by new { c.ID, c.Name } into studentCourse
                                       select new CourseStudentNumber
                                       {
                                           CourseName = studentCourse.Key.Name,
                                           TotalStudentRegister = studentCourse.Count()
                                       }).Take(3).ToListAsync();

            var studentPerYear = await _context.Students
                .Where(s => s.Deleted != 1 && s.CreatedAt.Value.Year >= DateTime.Now.Year - 9).ToListAsync();
            res.StudentPerYear = new List<StudentPerYear>();
            for (var i = DateTime.Now.Year - 9;i <= DateTime.Now.Year; i++)
            {
                res.StudentPerYear.Add(new StudentPerYear
                {
                    Year = i,
                    TotalStudent = studentPerYear.Where(s => s.CreatedAt.Value.Year == i).Count(),
                    TotalStudentGraduating = studentPerYear.Where(s => s.UpdatedAt.Value.Year == i && s.Status == 3).Count()
                });
            }

            res.TotalStudent = await _context.Students.Where(d => d.Deleted != 1).CountAsync();
            res.TotalCourse = await _context.Courses.Where(d => d.Deleted != 1).CountAsync();
            res.TotalCourseAvaiable = await _context.Courses.Where(d => d.Deleted != 1 && d.Status == 0).CountAsync();
            res.TotalFaculty = await _context.Faculties.Where(d => d.Deleted != 1).CountAsync();
            res.TotalPost = await _context.Contents.Where(d => d.Deleted != 1 && d.Type == 2).CountAsync();
            res.TotalStudentAdmission = await _context.Students.Where(d => d.Deleted != 1 && d.Status == 1).CountAsync();

            return View(res);
        }
        public async Task<IActionResult> StudentPerYear()
        {
            var studentPerYear = _context.Students
                   .Where(s => s.Deleted != 1 && s.CreatedAt.Value.Year >= DateTime.Now.Year - 9);
            var res = new List<StudentPerYear>();
            for (var i = DateTime.Now.Year - 9;i <= DateTime.Now.Year; i++)
            {
                res.Add(new StudentPerYear
                {
                    Year = i,
                    TotalStudent = studentPerYear.Where(s => s.Course.StartDate.Value.Year == i).Count(),
                    TotalStudentAdmission = studentPerYear.Where(s => s.Course.StartDate.Value.Year == i && s.Status == 1).Count(),
                    TotalStudentFailed = studentPerYear.Where(s => s.Course.StartDate.Value.Year == i && s.Status == 3).Count(),
                    TotalStudentGraduating = studentPerYear.Where(s => s.Course.StartDate.Value.Year == i && s.Status == 4).Count(),
                    TotalStudentExpelled = studentPerYear.Where(s => s.Course.StartDate.Value.Year == i && s.Status == 2).Count()
                });
            }

            return Json(new { 
                YearList = res.Select(r => r.Year),
                TotalStudent = res.Select(r => r.TotalStudent),
                TotalStudentGraduating = res.Select(r => r.TotalStudentGraduating),
                TotalStudentExpelled = res.Select(r => r.TotalStudentExpelled),
                TotalStudentAdmission = res.Select(r => r.TotalStudentAdmission),
                TotalStudentFailed = res.Select(r => r.TotalStudentFailed),
            });
        }
    }
}
