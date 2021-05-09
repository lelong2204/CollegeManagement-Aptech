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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Admin/Student
        public async Task<IActionResult> List()
        {
            return View(await _context.Students.ToListAsync());
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

            res.CourseList = _context.Courses.Where(d => d.Deleted != 1)
                .OrderByDescending(d => d.UpdatedAt)
                .Select(d => new DepartmentSelectDTO
                {
                    ID = (int)d.ID,
                    Name = d.Name
                });

            return View(res);
        }

        // POST: Admin/Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,FatherName,MotherName,Code,Email,PhoneNumber,ResidentialAddress,PermanentAddress,ImageURL,Gender,DOB,Status,CourseID,Admission,TestScore,ID,Deleted,CreatedAt,UpdatedAt")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
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
                CourseList = _context.Courses.Where(d => d.Deleted != 1)
                    .OrderByDescending(d => d.UpdatedAt)
                    .Select(d => new DepartmentSelectDTO
                    {
                        ID = (int)d.ID,
                        Name = d.Name
                    }),
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
        public async Task<IActionResult> Edit(int id, [Bind("Name,FatherName,MotherName,Code,Email,PhoneNumber,ResidentialAddress,PermanentAddress,ImageURL,Gender,DOB,Status,CourseID,Admission,TestScore,ID,Deleted,CreatedAt,UpdatedAt")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
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
            return View(student);
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
