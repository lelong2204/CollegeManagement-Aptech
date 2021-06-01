using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using CollegeManagement.DTO.FacilityDTO;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(RoleType = "Admin, SuperAdmin")]
    public class FacilityController : BaseController
    {
        private readonly DataContext _context;

        public FacilityController(DataContext context)
        {
            _context = context;
        }

        // GET: Facility
        public IActionResult Index()
        {
            return View();
        }

        // GET: Facility
        public async Task<IActionResult> List()
        {
            return Json(new
            {
                status = true,
                msg = MESSAGE_SUCCESS,
                data = await _context.Facilities.ToListAsync()
            }); 
        }

        // GET: Facility/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // GET: Facility/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facility/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(FacilityUpSertDTO req)
        {
            try
            {
                var pathList =  await Utils.SaveMultiFile(req.Imgs, "Facility");

                var facility = new Facility
                {
                    Name = req.Name,
                    Info = req.Info,
                    Qty = req.Qty,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Add(facility);
                await _context.SaveChangesAsync();
                    
                if (pathList != null && pathList.Count() > 0)
                {
                    var facilityImgs = new List<FacilityImg>();

                    foreach (var path in pathList)
                    {
                        facilityImgs.Add(new FacilityImg
                        {
                            FacilityId = facility.ID,
                            ImgUrl = path
                        });
                    }

                    await _context.FacilityImg.AddRangeAsync(facilityImgs);
                    await _context.SaveChangesAsync();
                }

                TempData["Success"] = MESSAGE_SUCCESS;
                return new JsonResult(new { code = 200, message = MESSAGE_SUCCESS, status = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { code = 200, message = ex.Message, status = false });
            }
        }

        // GET: Facility/Edit/5
        public IActionResult Edit(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        // GET: Facility/Edit/5
        public async Task<IActionResult> GetDetailData(int? id)
        {
            if (id == null)
            {
                return new JsonResult(new { code = 200, message = MESSAGE_NOT_FOUND, status = false });
            }

            var facility = await (from f in _context.Facilities
                                 where f.ID == id
                                 select new FacilityUpSertDTO
                                 {
                                     ID = f.ID,
                                     ImgUrls = f.FacilityImgs.ToList(),
                                     Info = f.Info,
                                     Name = f.Name,
                                     Qty = f.Qty
                                 }).FirstOrDefaultAsync();

            if (facility == null)
            {
                return new JsonResult(new { code = 200, message = MESSAGE_NOT_FOUND, status = false });
            }

            return new JsonResult(new { code = 200, status = true, data = facility });
        }

        // POST: Facility/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(FacilityUpSertDTO req)
        {
            try
            {
                var facility = await _context.Facilities.FindAsync(req.ID);

                if (facility == null)
                {
                    return new JsonResult(new { code = 200, message = MESSAGE_NOT_FOUND, status = false });
                }

                var pathList = await Utils.SaveMultiFile(req.Imgs, "Facility");

                facility.Name = req.Name;
                facility.Info = req.Info;
                facility.Qty = req.Qty;
                facility.UpdatedAt = DateTime.Now;

                _context.Update(facility);

                if (pathList != null && pathList.Count() > 0)
                {
                    var facilityImgs = new List<FacilityImg>();

                    foreach (var path in pathList)
                    {
                        facilityImgs.Add(new FacilityImg
                        {
                            FacilityId = facility.ID,
                            ImgUrl = path
                        });
                    }

                    await _context.FacilityImg.AddRangeAsync(facilityImgs);
                }

                if (req.ImgsDelete != null && req.ImgsDelete.Count > 0)
                {
                    _context.FacilityImg.RemoveRange(_context.FacilityImg.Where(fi => req.ImgsDelete.Contains(fi.Id)).ToList());
                }
                await _context.SaveChangesAsync();
                TempData["Success"] = MESSAGE_SUCCESS;
                return new JsonResult(new { code = 200, message = MESSAGE_SUCCESS, status = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { code = 200, message = ex.Message, status = false });
            }
        }

        // GET: Facility/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // POST: Facility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var facility = await _context.Facilities.FindAsync(id);
            _context.Facilities.Remove(facility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilityExists(int? id)
        {
            return _context.Facilities.Any(e => e.ID == id);
        }
    }
}
