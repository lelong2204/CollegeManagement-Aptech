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
                                      Admission = s.Admission,
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
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Admin/Student/Create
        public IActionResult Create()
        {
            var res = new StudentUpsertDTO();

            res.CourseList = _context.Courses
                .Where(d => d.Deleted != 1 && d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now)
                .OrderByDescending(d => d.UpdatedAt)
                .Select(d => new DepartmentSelectDTO
                {
                    ID = (int)d.ID,
                    Name = d.Name
                }).ToList();

            return View(res);
        }

        // POST: Admin/Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentUpsertDTO req)
        {
            if (ModelState.IsValid)
            {
                var imgPath = await Utils.SaveFile(req.Image, "Student");
                var code = await CreateCode();

                var student = new Student
                {
                    CourseID = req.CourseID,
                    Admission = req.Admission,
                    Status = req.Status,
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
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
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
                Admission = student.Admission,
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

        // POST: Admin/Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentUpsertDTO req)
        {
            if (id != req.ID)
            {
                return NotFound();
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
                    student.Admission = req.Admission;
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
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(req);
        }

        // GET: Admin/Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Admin/Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
