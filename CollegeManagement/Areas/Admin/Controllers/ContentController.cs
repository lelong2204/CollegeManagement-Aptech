using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Http;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContentController : BaseController
    {
        private readonly DataContext _context;

        public ContentController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Contents
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
                    data = await _context.Contents.Where(d => d.Deleted != 1)
                        .OrderByDescending(d => d.UpdatedAt).ToListAsync()
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    msg = ex.Message,
                    data = new List<Content>()
                });
            }
        }

        [HttpPost()]
        [RequestSizeLimit(1024L*1024L*1000L)]
        public async Task<string> UploadImg(IFormFile file)
        {
            return await Utils.SaveFile(file, "Content");
        }

        // GET: Admin/Contents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                var content = await _context.Contents
                    .FirstOrDefaultAsync(c => c.ID == id && c.Deleted != 1);
                if (content == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                return View(content);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Admin/Contents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.ValidateInput(false)]
        public async Task<IActionResult> Create(Content content)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    content.CreatedAt = DateTime.Now;
                    content.UpdatedAt = DateTime.Now;
                    if (content.Type != 1)
                    {
                        content.Year = null;
                    }
                    else if (_context.Contents.Any(c => c.Year == content.Year && c.Deleted != 1))
                    {
                        TempData["Error"] = $"The {content.Year} already exists";
                        return View(content);
                    }
                    _context.Add(content);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                TempData["Success"] = MESSAGE_SUCCESS;
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(content);
            }
        }

        // GET: Admin/Contents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                var content = await _context.Contents
                    .FirstOrDefaultAsync(c => c.ID == id && c.Deleted != 1);
                if (content == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new Content());
            }
        }

        // POST: Admin/Contents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Content content)
        {
            if (id != content.ID)
            {
                TempData["Error"] = MESSAGE_NOT_FOUND;
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!ContentExists(content.ID))
                    {
                        TempData["Error"] = MESSAGE_NOT_FOUND;
                        return RedirectToAction(nameof(Index));
                    }

                    content.UpdatedAt = DateTime.Now;
                    _context.Update(content);
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
            return View(content);
        }

        // GET: Admin/Contents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                var content = await _context.Contents
                    .FirstOrDefaultAsync(c => c.ID == id && c.Deleted != 1);
                if (content == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            try
            {
                var content = await _context.Contents.FirstOrDefaultAsync(c => c.ID == id && c.Deleted != 1);
                if (content == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                content.Deleted = 1;
                _context.Contents.Update(content);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ContentExists(int? id)
        {
            return _context.Contents.Any(e => e.ID == id && e.Deleted != 1);
        }
    }
}
