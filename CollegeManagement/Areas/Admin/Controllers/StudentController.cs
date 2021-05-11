using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using CollegeManagement.DTO.Student;
using CollegeManagement.DTO.Departments;
using CollegeManagement.DTO.Faculty;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : BaseController
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Student
        public IActionResult Index()
        {
            return View();
        }

        // GET: Admin/Student
        public async Task<IActionResult> List()
        {
            try
            {
                var data = await (from s in _context.Students
                                  join d in _context.Courses on s.CourseID equals d.ID
                                  into d
                                  from ds in d.DefaultIfEmpty()
                                  where s.Deleted != 1
                                  orderby s.UpdatedAt descending
                                  select new
                                  {
                                      ID = s.ID,
                                      Name = s.Name,
                                      Code = s.Code,
                                      CourseName = ds.Name,
                                      Gender = s.Gender,
                                      DOB = s.DOB,
                                      Status = s.Status,
                                      ImageURL = s.ImageURL,
                                      TestScore = s.TestScore
                                  }).ToListAsync();
                return Json(new
                {
                    status = true,
                    msg = MESSAGE_SUCCESS,
                    data = data
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    msg = ex.Message,
                    data = new List<Course>()
                });
            }
        }

        // GET: Admin/Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                var student = await _context.Students
                    .FirstOrDefaultAsync(m => m.ID == id && m.Deleted != 1);
                if (student == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                return View(student);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new Student());
            }
        }

        // GET: Admin/Student/Create
        public IActionResult Create()
        {
            var res = new StudentUpsertDTO();

            try
            {
                res.CourseList = _context.Courses
                    .Where(d => d.Deleted != 1 && d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now)
                    .OrderByDescending(d => d.UpdatedAt)
                    .Select(d => new DepartmentSelectDTO
                    {
                        ID = (int)d.ID,
                        Name = d.Name
                    }).ToList();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View(res);
        }

        // POST: Admin/Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentUpsertDTO req)
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
                        Status = (int?)StudentUpsertDTO.StudentStatus.Processing,
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
                    TempData["Success"] = MESSAGE_SUCCESS;
                    return RedirectToAction(nameof(Index));
                }

                req.CourseList = _context.Courses
                    .Where(d => d.Deleted != 1 && d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now)
                    .OrderByDescending(d => d.UpdatedAt)
                    .Select(d => new DepartmentSelectDTO
                    {
                        ID = (int)d.ID,
                        Name = d.Name
                    }).ToList();
                return View(req);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
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

        // GET: Admin/Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                var student = await _context.Students.FirstOrDefaultAsync(c => c.ID == id && c.Deleted != 1);
                if (student == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }
                var res = new StudentUpsertDTO
                {
                    CourseList = _context.Courses
                    .Where(d => d.Deleted != 1 && d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now)
                        .OrderByDescending(d => d.UpdatedAt)
                        .Select(d => new DepartmentSelectDTO
                        {
                            ID = (int)d.ID,
                            Name = d.Name
                        }).ToList(),
                    CourseID = student.CourseID,
                    ID = student.ID,
                    Status = student.Status,
                    Code = student.Code,
                    DOB = student.DOB,
                    Email = student.Email,
                    Gender = student.Gender,
                    ImageURL = student.ImageURL,
                    Name = student.Name,
                    PermanentAddress = student.PermanentAddress,
                    PhoneNumber = student.PhoneNumber,
                    ResidentialAddress = student.ResidentialAddress,
                    ResponsiblePersonName = student.ResponsiblePersonName,
                    ResponsiblePersonPhone = student.ResponsiblePersonPhone,
                    TestScore = student.TestScore
                };
                return View(res);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new Student());
            }
        }

        // POST: Admin/Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentUpsertDTO req)
        {
            if (id != req.ID)
            {
                TempData["Error"] = MESSAGE_NOT_FOUND;
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var student = await _context.Students
                        .FirstOrDefaultAsync(s => s.Deleted != 1 && s.ID == id);

                    if (student == null)
                    {
                        return NotFound();
                    }

                    var imgPath = await Utils.SaveFile(req.Image, "Student");
                    student.CourseID = req.CourseID;
                    student.Status = req.Status;
                    student.Code = req.Code;
                    student.DOB = req.DOB;
                    student.Email = req.Email;
                    student.Gender = req.Gender;
                    student.ImageURL = imgPath;
                    student.Name = req.Name;
                    student.PermanentAddress = req.PermanentAddress;
                    student.PhoneNumber = req.PhoneNumber;
                    student.ResidentialAddress = req.ResidentialAddress;
                    student.ResponsiblePersonName = req.ResponsiblePersonName;
                    student.ResponsiblePersonPhone = req.ResponsiblePersonPhone;
                    student.TestScore = req.TestScore;
                    student.UpdatedAt = DateTime.Now;

                    _context.Update(req);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return RedirectToAction(nameof(Index));
                }
                TempData["Success"] = MESSAGE_SUCCESS;
                return RedirectToAction(nameof(Index));
            }
            return View(req);
        }

        // GET: Admin/Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                var student = await _context.Students
                    .FirstOrDefaultAsync(m => m.ID == id && m.Deleted != 1);
                if (student == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                return View(student);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new Student());
            }
        }

        // POST: Admin/Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var student = await _context.Students
                          .FirstOrDefaultAsync(m => m.ID == id && m.Deleted != 1);
                if (student == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }
                student.Deleted = 1;
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                TempData["Success"] = MESSAGE_SUCCESS;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id && e.Deleted != 1);
        }

        public List<FacultySelectDTO> Select2(string search)
        {
            try
            {
                search = string.IsNullOrEmpty(search) ? "" : search.ToLower();
                var students = _context.Students
                    .Where(f => f.Name.ToLower().Contains(search) && 
                        f.Deleted != 1 && f.Status == 1 && (f.UserID == null || f.UserID == 0)
                    );

                return (from s in students
                        select new FacultySelectDTO { ID = s.ID, Name = s.Name }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
