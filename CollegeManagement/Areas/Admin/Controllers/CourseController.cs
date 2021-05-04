using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using CollegeManagement.DTO.Course;
using CollegeManagement.DTO.Subject;
using CollegeManagement.DTO.Departments;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Course
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: Admin/Course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Admin/Course/Create
        public IActionResult Create()
        {
            var res = new CourseUpSertDTO();

            res.DepartmentList = _context.Departments.Where(d => d.Deleted != 1)
                .OrderByDescending(d => d.UpdatedAt)
                .Select(d => new DepartmentSelectDTO
                {
                    ID = (int)d.ID,
                    Name = d.Name
                });

            res.SubjectList = _context.Subjects.Where(d => d.Deleted != 1)
                .OrderByDescending(d => d.UpdatedAt)
                .Select(d => new SubjectSelectDTO
                {
                    ID = (int)d.ID,
                    Name = d.Name
                });

            return View(res);
        }

        // POST: Admin/Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseUpSertDTO req)
        {
            if (ModelState.IsValid)
            {
                var imgPath = await Utils.SaveFile(req.Image, "Course");

                var course = new Course
                {
                    DepartmentID = req.DepartmentID,
                    Focus = req.Focus,
                    ImageURL = imgPath,
                    Name = req.Name,
                    Info = req.Info,
                    Price = req.Price,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                };

                _context.Add(course);
                await _context.SaveChangesAsync();

                var courseSubjectList = new List<CourseSubject>();

                if (req.SubjectIDs != null && req.SubjectIDs.Count() > 0)
                {
                    var subjectIDs = req.SubjectIDs.Distinct<int>();
                    foreach (var subjectID in subjectIDs)
                    {
                        courseSubjectList.Add(new CourseSubject { SubjectID = subjectID, CourseID = (int)course.ID });
                    }

                    await _context.CourseSubjects.AddRangeAsync(courseSubjectList);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(req);
        }

        // GET: Admin/Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Admin/Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseUpSertDTO req)
        {
            if (id != req.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var imgPath = await Utils.SaveFile(req.Image, "Faculty");
                    _context.Update(req);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(id))
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

        // GET: Admin/Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Admin/Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.ID == id);
        }
    }
}
