using System;
using System.Linq;
using System.Threading.Tasks;
using CollegeManagement.DTO.CourseDTO;
using CollegeManagement.DTO.DepartmentsDTO;
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
                .OrderBy(c => c.Year).ToListAsync();
            res.Courses = await _context.Courses.Where(c => c.Deleted != 1)
                .OrderByDescending(c => c.UpdatedAt).Take(3).ToListAsync();
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

        [Route("/Home/Faculties/{id?}")]
        [Route("/Home/Faculties")]
        public IActionResult Faculties(int? id)
        {
            if (id != null)
            {
                var res = _context.Faculties.Where(c => c.Deleted != 1 && c.DepartmentID == id)
                    .Select(c => new Faculty
                    {
                        ID = c.ID,
                        ImageUrl = c.ImageUrl,
                        Name = c.Name,
                        Department = c.Department,
                        Gender = c.Gender,
                        Email = c.Email
                    });
                return View(res);
            }
            else
            {
                var res = _context.Faculties.Where(c => c.Deleted != 1)
                    .Select(c => new Faculty
                    {
                        ID = c.ID,
                        ImageUrl = c.ImageUrl,
                        Name = c.Name,
                        Department = c.Department,
                        Gender = c.Gender,
                        Email = c.Email
                    });
                return View(res);
            }
        }

        [Route("/Home/Courses/{id?}")]
        [Route("/Home/Courses")]
        public IActionResult Courses(int? id)
        {
            if (id != null)
            {
                var res = _context.Courses.Where(c => c.Deleted != 1 && c.DepartmentID == id)
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
            else
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
        }

        [Route("/Home/Courses/Register")]
        public async Task<IActionResult> RegisterCourses2()
        {
            var res = new StudentRegisterDTO();
            res.CourseList = await _context.Courses
                .Where(c => c.Deleted != 1 &&
                    c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now && c.Status != 1)
                .Select(c => new CourseSelectDTO {
                    ID = c.ID,
                    Name = $"{c.Name} - {c.Code}"
                }).ToListAsync();

            return View(res);
        }

        [Route("/Home/Courses/Register/{id?}")]
        public async Task<IActionResult> RegisterCourses(int? id)
        {
            var res = new StudentRegisterDTO();
            res.Course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Deleted != 1 && c.ID == id &&
                    c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now && c.Status != 1);

            if (res.Course == null)
            {
                TempData["Error"] = "Course not found or can't register";
                return RedirectToAction(nameof(Courses));
            }

            return View(res);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoRegisterCourses(StudentRegisterDTO req)
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

        [Route("/Home/Courses/Details/{id?}")]
        public async Task<IActionResult> CourseDetails(int? id)
        {
            var res = await (from c in _context.Courses
                                where c.Deleted != 1 && c.ID == id
                                select new CourseDetailsDTO
                                {
                                    DepartmentID = c.DepartmentID,
                                    DepartmentName = c.Department.Name,
                                    Name = c.Name,
                                    EndDate = c.EndDate,
                                    ImageURL = c.ImageURL,
                                    ID = c.ID,
                                    Info = c.Info,
                                    StudentNumber = c.StudentNumber,
                                    StudentRegisterNumber = c.Students.Count,
                                    StartDate = c.StartDate,
                                    Price = c.Price,
                                    Status = c.Status,
                                    Code = c.Code,
                                    SubjectList = c.CourseSubject.Select(cs => new CourseSubject
                                    {
                                        Faculty = cs.Faculty,
                                        FacultyID = cs.FacultyID,
                                        Subject = cs.Subject,
                                        SubjectID = cs.SubjectID
                                    })
                                }).FirstOrDefaultAsync();

            if (res == null)
            {
                TempData["Error"] = "Course not found";
                return RedirectToAction(nameof(Courses));
            }

            return View(res);
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
            var res = _context.Departments.Where(c => c.Deleted != 1)
                        .OrderByDescending(c => c.ID)
                            .Select(d => new DepartmentDataDTO {
                                Name = d.Name,
                                Info = d.Info,
                                ID = d.ID,
                                FacultyCount = d.Faculties.Count(),
                            });
            return View(res);
        }

        public IActionResult Blog()
        {
            var res = _context.Contents.Where(c => c.Deleted != 1 && c.Type == 2);
            return View(res);
        }


        [Route("/Home/Blog/Details/{id?}")]
        public IActionResult BlogDetails(int? id)
        {
            var res = _context.Contents.FirstOrDefault(c => c.Deleted != 1 && c.Type == 2 && c.ID == id);
            if (res == null)
            {
                TempData["Error"] = "Blog not found";
                return RedirectToAction(nameof(Blog));
            }
            return View(res);
        }
    }
}