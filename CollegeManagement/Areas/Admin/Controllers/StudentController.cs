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

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.Where(s => s.Deleted != 1).ToListAsync());
        }

        // GET: Students/Details/5
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

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentUpsertDTO req)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = req.Name,
                    Code = req.Code,
                    Address = req.Address,
                    DOB = req.DOB,
                    Email = req.Email,
                    PhoneNumber = req.Phone,
                    Gender = req.Gender,
                    ImageURL = await Utils.SaveFile(req.Image, "Student"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(req);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.ID == id && s.Deleted != 1);

            if (student == null)
            {
                return NotFound();
            }

            var res = new StudentUpsertDTO
            {
                ID = student.ID,
                Name = student.Name,
                Address = student.Address,
                DOB = student.DOB,
                Email = student.Email,
                Gender = student.Gender,
                Code = student.Code,
                ImageURL = student.ImageURL,
                Phone = student.PhoneNumber,
            };

            return View(res);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, StudentUpsertDTO req)
        {
            if (id != req.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var imgPath = await Utils.SaveFile(req.Image, "Student");
                    var student = await _context.Students
                                    .FirstOrDefaultAsync(s => s.ID == id && s.Deleted != 1);

                    if (student == null) return NotFound();

                    student.Name = req.Name;
                    student.Code = req.Code;
                    student.Address = req.Address;
                    student.DOB = req.DOB;
                    student.Email = req.Email;
                    student.PhoneNumber = req.Phone;
                    student.Gender = req.Gender;
                    student.ImageURL = string.IsNullOrWhiteSpace(imgPath) ? student.ImageURL: imgPath;
                    student.UpdatedAt = DateTime.Now;

                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(req);
        }

        // GET: Students/Delete/5
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

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var student = await _context.Students.FindAsync(id);
            student.Deleted = 1;
            student.UpdatedAt = DateTime.Now;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int? id)
        {
            return _context.Students.Any(e => e.ID == id && e.Deleted != 1);
        }
    }
}
