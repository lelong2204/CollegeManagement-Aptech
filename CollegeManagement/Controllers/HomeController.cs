using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeManagement.DTO.Home;
using CollegeManagement.Helper;
using CollegeManagement.Models;
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
            var res = _context.Courses.Where(c => c.Deleted != 1)
                .Select(c => new CourseHome
                {
                    ID = c.ID,
                    DepartmentID = c.DepartmentID,
                    EndDate = c.EndDate,
                    StartDate = c.StartDate,
                    ImageURL = c.ImageURL,
                    Info = c.Info,
                    Name = c.Name,
                    Status = c.Status,
                    StudentNumber = c.StudentNumber,
                    TotalBook = c.CourseSubject.Count(),
                    StudentRegister = c.Students.Count(),
                });

            return View(res);
        }

        [Route("/Home/Courses/Register/{id?}")]
        public async Task<IActionResult> RegisterCourses(int? id)
        {
            var res = new StudentRegisterDTO();
            res.Course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Deleted != 1 && 
                    c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now && c.Status != 1);

            if (res.Course == null)
            {
                return RedirectToAction(nameof(Courses));
            }

            return View(res);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCourses(StudentRegisterDTO req)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imgPath = await Utils.SaveFile(req.Image, "Student");
                    var code = await CreateCode();

                    var student = new Student
                    {
                        CourseID = req.CourseID,
                        Status = 1,
                        Code = code,
                        DOB = req.DOB,
                        Email = req.Email,
                        Gender = req.Gender,
                        ImageURL = imgPath,
                        Name = req.Name,
                        PermanentAddress = req.PermanentAddress,
                        PhoneNumber = req.PhoneNumber,
                        ResidentialAddress = req.ResidentialAddress,
                        ResponsiblePersonName = req.ResponsiblePersonName,
                        ResponsiblePersonPhone = req.ResponsiblePersonPhone,
                        TestScore = req.TestScore,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Successfully";
                    return RedirectToAction(nameof(Courses));
                }

                req.Course = await _context.Courses
                    .FirstOrDefaultAsync(c => c.Deleted != 1 &&
                    c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now && c.Status != 1);
                return View(req);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Courses));
            }
        }

        private async Task<string> CreateCode()
        {
            var code = $"STD{DateTimeOffset.Now.ToUnixTimeMilliseconds()}";

            if (await _context.Students.AnyAsync(s => s.Code.Equals(code)))
            {
                return await CreateCode();
            }

            return code;
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