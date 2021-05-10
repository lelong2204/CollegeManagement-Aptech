using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using CollegeManagement.Departments.DTO;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DepartmentController : BaseController
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        // GET: Department
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
                    data = await _context.Departments.Where(d => d.Deleted != 1)
                        .OrderByDescending(d => d.UpdatedAt).ToListAsync()
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    msg = ex.Message,
                    data = new List<Department>()
                });
            }
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {

                if (id == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                var department = await _context.Departments
                    .FirstOrDefaultAsync(m => m.ID == id && m.Deleted != 1);

                if (department == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                return View(department);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new Department());
            }
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.CreatedAt = DateTime.Now;
                    department.UpdatedAt = DateTime.Now;
                    _context.Add(department);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                TempData["Success"] = MESSAGE_SUCCESS;
                return View(department);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(department);
            }
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                var department = await _context.Departments
                    .FirstOrDefaultAsync(d => d.Deleted != 1 && d.ID == id);
                if (department == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }
                return View(department); ;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new Department());
            }
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, DepartmentUpSertDTO req)
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
                    var department = await _context.Departments.
                        FirstOrDefaultAsync(d => d.ID == req.ID && d.Deleted !=  1);

                    department.Name = req.Name;
                    department.Info = req.Info;
                    department.UpdatedAt = DateTime.Now;

                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (!DepartmentExists(req.ID))
                    {
                        TempData["Error"] = MESSAGE_NOT_FOUND;
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Error"] = ex.Message;
                        return View(req);
                    }
                }
                TempData["Success"] = MESSAGE_SUCCESS;
                return RedirectToAction(nameof(Index));
            }
            return View(req);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                var department = await _context.Departments
                    .FirstOrDefaultAsync(d => d.Deleted != 1 && d.ID == id);
                if (department == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }
                return View(department); ;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new Department());
            }
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            try
            {
                var department = await _context.Departments
                    .FirstOrDefaultAsync(d => d.ID == id && d.Deleted != 1);

                if (department == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                department.Deleted = 1;

                _context.Departments.Update(department);
                await _context.SaveChangesAsync();

                TempData["Success"] = MESSAGE_DELETE_SUCCESS;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        private bool DepartmentExists(int? id)
        {
            return _context.Departments.Any(e => e.ID == id && e.Deleted != 1);
        }
    }
}
