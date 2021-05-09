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
    [Area("Admin")]
    [Authorize]
    public class SubjectController : BaseController
    {
        private readonly DataContext _context;

        public SubjectController(DataContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            try
            {
                return Json(new
                {
                    status = true,
                    msg = MESSAGE_SUCCESS,
                    data = await _context.Subjects.Where(d => d.Deleted != 1)
                        .OrderByDescending(d => d.UpdatedAt).ToListAsync()
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    msg = ex.Message,
                    data = new List<Faculty>()
                });
            }
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

        public List<SubjectSelectDTO> Select2(string search, int facultyID, List<int> subjectExist)
        {
            try
            {
                search = string.IsNullOrEmpty(search) ? "" : search.ToLower();
                var subjects = _context.Subjects.Where(s => !subjectExist.Contains(s.ID)
                        && s.Name.ToLower().Contains(search) && s.Deleted != 1);

                if (facultyID > 0)
                {
                    return (from f in subjects
                            join fs in _context.FacultySubjects on f.ID equals fs.SubjectID into m
                            from fs in m.DefaultIfEmpty()
                            where fs.FacultyID == facultyID
                            select new SubjectSelectDTO { ID = f.ID, Name = f.Name }).ToList();
                }

                return (from s in subjects
                        select new SubjectSelectDTO { ID = s.ID, Name = s.Name }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool SubjectExists(int? id)
        {
            return _context.Subjects.Any(e => e.ID == id && e.Deleted != 1);
        }
    }
}
