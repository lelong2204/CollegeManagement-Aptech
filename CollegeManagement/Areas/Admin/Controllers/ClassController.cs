using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using CollegeManagement.DTO.Class;
using CollegeManagement.DTO.Course;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassController : Controller
    {
        private readonly DataContext _context;

        public ClassController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Class
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classes.ToListAsync());
        }

        // GET: Admin/Class/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // GET: Admin/Class/Create
        public IActionResult Create()
        {
            var res = new ClassUpSertDTO
            {
                CourseList = _context.Courses.Where(c => c.Deleted != 1)
                    .OrderByDescending(c => c.UpdatedAt).Select(c => new CourseSelectDTO
                    {
                        ID = c.ID,
                        Name = c.Name
                    })
            };

            return View(res);
        }

        // POST: Admin/Class/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassUpSertDTO req)
        {
            if (ModelState.IsValid)
            {
                var data = new Class
                {
                    CourseID = req.CourseID,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    MaxStudentPerClass = req.MaxStudentPerClass,
                    Name = req.Name
                };
                _context.Classes.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(req);
        }

        // GET: Admin/Class/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.Classes.FirstOrDefaultAsync(c => c.ID == id && c.Deleted != 1);
            if (data == null)
            {
                return NotFound();
            }

            var res = new ClassUpSertDTO
            {
                CourseList = _context.Courses.Where(c => c.Deleted != 1)
                    .OrderByDescending(c => c.UpdatedAt).Select(c => new CourseSelectDTO
                    {
                        ID = c.ID,
                        Name = c.Name
                    }),
                CourseID = data.CourseID,
                ID = data.ID,
                MaxStudentPerClass = data.MaxStudentPerClass,
                Name = data.Name 
            };
            return View(res);
        }

        // POST: Admin/Class/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,MaxStudentPerClass,CourseID,ID,Deleted,CreatedAt,UpdatedAt")] Class @class)
        {
            if (id != @class.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.ID))
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
            return View(@class);
        }

        // GET: Admin/Class/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Admin/Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @class = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
            return _context.Classes.Any(e => e.ID == id);
        }
    }
}
