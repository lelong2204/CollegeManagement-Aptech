using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactSupportController : BaseController
    {
        private readonly DataContext _context;

        public ContactSupportController(DataContext context)
        {
            _context = context;
        }

        // GET: ContactSupport
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactSupports.ToListAsync());
        }

        // GET: ContactSupport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactSupport = await _context.ContactSupports
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactSupport == null)
            {
                return NotFound();
            }

            return View(contactSupport);
        }

        // GET: ContactSupport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactSupport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,PhoneNumber,Infomation,ID,Deleted,CreatedAt,UpdatedAt")] ContactSupport contactSupport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactSupport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactSupport);
        }

        // GET: ContactSupport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactSupport = await _context.ContactSupports.FindAsync(id);
            if (contactSupport == null)
            {
                return NotFound();
            }
            return View(contactSupport);
        }

        // POST: ContactSupport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("FirstName,LastName,Email,PhoneNumber,Infomation,ID,Deleted,CreatedAt,UpdatedAt")] ContactSupport contactSupport)
        {
            if (id != contactSupport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactSupport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactSupportExists(contactSupport.ID))
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
            return View(contactSupport);
        }

        // GET: ContactSupport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactSupport = await _context.ContactSupports
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactSupport == null)
            {
                return NotFound();
            }

            return View(contactSupport);
        }

        // POST: ContactSupport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var contactSupport = await _context.ContactSupports.FindAsync(id);
            _context.ContactSupports.Remove(contactSupport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactSupportExists(int? id)
        {
            return _context.ContactSupports.Any(e => e.ID == id);
        }
    }
}
