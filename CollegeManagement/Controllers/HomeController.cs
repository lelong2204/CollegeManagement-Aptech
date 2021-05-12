using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeManagement.DTO.Home;
using CollegeManagement.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var res = new UserHome();
            res.Histories = await _context.Contents.Where(c => c.Type == 1 && c.Deleted != 1)
                .OrderByDescending(c => c.Year).ToListAsync();
            res.Courses = await _context.Courses.Where(c => c.Deleted != 1 && c.Status != 1)
                .OrderByDescending(c => c.Focus).OrderByDescending(c => c.UpdatedAt).Take(3).ToListAsync();
            res.Faculties = await _context.Faculties.Where(c => c.Deleted != 1).Take(5).ToListAsync();
            res.Event = await _context.Contents.Where(c => c.Type == 2 && c.Deleted != 1)
                .OrderByDescending(c => c.UpdatedAt).Take(3).ToListAsync();
            res.TotalStudent = _context.Students.Where(s => s.Deleted != 1 && s.Status == 1).Count();
            res.TotalCourse = _context.Courses.Where(s => s.Deleted != 1).Count();
            if (res.Histories != null && res.Histories.Any())
            {
                res.Year = DateTime.Now.Year - (int)res.Histories.Min(h => h.Year);
            }
            return View(res);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Faculties()
        {
            return View();
        }

        public IActionResult Courses()
        {
            return View();
        }

        public IActionResult Departments()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }


    }
}