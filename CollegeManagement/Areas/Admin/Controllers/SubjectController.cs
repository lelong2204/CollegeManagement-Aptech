using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using CollegeManagement.DTO.Subject;

namespace CollegeManagement.Areas.Admin.Controllers
{
    public class SubjectController : BaseController
    {
        private readonly DataContext _context;

        public SubjectController(DataContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subjects.Where(s => s.Deleted != 1).ToListAsync());
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubjectUpSertDTO req)
        {
            if (ModelState.IsValid)
            {
                var imgPath = await Utils.SaveFile(req.Image, "Subject");

                var subject = new Subject
                {
                    Name = req.Name,
                    Info = req.Info,
                    BasicDuration = req.BasicDuration,
                    AdvancedDuration = req.AdvancedDuration,
                    ImageUrl = imgPath,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(req);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(s => s.ID == id && s.Deleted != 1);

            if (subject == null)
            {
                return NotFound();
            }

            var res = new SubjectUpSertDTO
            {
                ID = subject.ID,
                BasicDuration = subject.BasicDuration,
                AdvancedDuration = subject.AdvancedDuration,
                ImageUrl = subject.ImageUrl,
                Info = subject.Info,
                Name = subject.Name
            };

            return View(res);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SubjectUpSertDTO req)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var subject = await _context.Subjects
                        .FirstOrDefaultAsync(s => s.ID == req.ID && s.Deleted != 1);

                    if (subject == null)
                    {
                        return NotFound();
                    }

                    var imgPath = await Utils.SaveFile(req.Image, "Subject");

                    subject.Info = req.Info;
                    subject.Name = req.Name;
                    subject.AdvancedDuration = req.AdvancedDuration;
                    subject.BasicDuration = req.BasicDuration;
                    subject.ImageUrl = string.IsNullOrEmpty(imgPath) ? subject.ImageUrl: imgPath;
                    subject.UpdatedAt = DateTime.Now;

                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(req.ID))
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

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.ID == id && m.Deleted != 1);

            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.ID == id && m.Deleted != 1);
            subject.Deleted = 1;

            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int? id)
        {
            return _context.Subjects.Any(e => e.ID == id && e.Deleted != 1);
        }
    }
}
