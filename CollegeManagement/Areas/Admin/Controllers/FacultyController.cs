﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using CollegeManagement.DTO.Faculty;
using System;
using CollegeManagement.DTO.Departments;
using CollegeManagement.DTO.Subject;
using System.Collections.Generic;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FacultyController : BaseController
    {
        private readonly DataContext _context;

        public FacultyController(DataContext context)
        {
            _context = context;
        }

        // GET: Faculties
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
                    data = await _context.Faculties.Where(d => d.Deleted != 1)
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

        // GET: Faculties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties
                .FirstOrDefaultAsync(m => m.ID == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // GET: Faculties/Create
        public IActionResult Create()
        {
            var res = new FacultyUpSertDTO();

            res.DepartmentList = _context.Departments.Where(d => d.Deleted != 1)
                .OrderByDescending(d => d.UpdatedAt)
                .Select(d => new DepartmentSelectDTO
                {
                    ID = (int) d.ID,
                    Name = d.Name
                });

            res.SubjectList = _context.Subjects.Where(d => d.Deleted != 1)
                .OrderByDescending(d => d.UpdatedAt)
                .Select(d => new SubjectSelectDTO
                {
                    ID = (int) d.ID,
                    Name = d.Name
                });

            return View(res);
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FacultyUpSertDTO req)
        {
            if (ModelState.IsValid)
            {
                var imgPath = await Utils.SaveFile(req.Image, "Faculty");

                var faculty = new Faculty
                {
                    Address = req.Address,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DepartmentID = req.DepartmentID,
                    DOB = req.DOB,
                    Email = req.Email,
                    ExperienceYear = req.ExperienceYear,
                    Gender = req.Gender,
                    ImageUrl = imgPath,
                    Info = req.Info,
                    Name = req.Name,
                    PhoneNumber = req.PhoneNumber
                };
                _context.Add(faculty);
                await _context.SaveChangesAsync();

                var facultySubjectList = new List<FacultySubject>();

                if (req.SubjectIDs != null && req.SubjectIDs.Count() > 0)
                {
                    var subjectIDs = req.SubjectIDs.Distinct<int>();
                    foreach (var subjectID in subjectIDs)
                    {
                        facultySubjectList.Add(new FacultySubject { SubjectID = subjectID, FacultyID = (int) faculty.ID });
                    }

                    await _context.FacultySubjects.AddRangeAsync(facultySubjectList);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(req);
        }

        // GET: Faculties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties.
                FirstOrDefaultAsync(d => d.ID == id && d.Deleted != 1);

            if (faculty == null)
            {
                return NotFound();
            }

            var res = new FacultyUpSertDTO
            {
                ID = faculty.ID,
                Name = faculty.Name,
                Info = faculty.Info,
                Gender = faculty.Gender,
                PhoneNumber = faculty.PhoneNumber,
                ExperienceYear = faculty.ExperienceYear,
                DepartmentID = faculty.DepartmentID,
                DOB = faculty.DOB,
                Address = faculty.Address,
                Email = faculty.Email,
                ImageUrl = faculty.ImageUrl,
                SubjectIDs = await _context.FacultySubjects
                    .Where(fs => fs.FacultyID == faculty.ID).Select(fs => fs.SubjectID).ToListAsync(),
                DepartmentList = _context.Departments.Where(d => d.Deleted != 1)
                    .OrderByDescending(d => d.UpdatedAt).Select(d => new DepartmentSelectDTO
                    {
                        ID = (int)d.ID,
                        Name = d.Name
                    }),
                SubjectList = _context.Subjects.Where(d => d.Deleted != 1)
                    .OrderByDescending(d => d.UpdatedAt).Select(d => new SubjectSelectDTO
                    {
                        ID = (int)d.ID,
                        Name = d.Name
                    })
            };

            return View(res);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, FacultyUpSertDTO req)
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

                    var faculty = await _context.Faculties
                        .FirstOrDefaultAsync(f => f.Deleted != 1 && f.ID == id);

                    faculty.Address = req.Address;
                    faculty.UpdatedAt = DateTime.Now;
                    faculty.DepartmentID = req.DepartmentID;
                    faculty.DOB = req.DOB;
                    faculty.Email = req.Email;
                    faculty.ExperienceYear = req.ExperienceYear;
                    faculty.Gender = req.Gender;
                    faculty.ImageUrl = string.IsNullOrEmpty(imgPath) ? faculty.ImageUrl: imgPath;
                    faculty.Info = req.Info;
                    faculty.Name = req.Name;
                    faculty.PhoneNumber = req.PhoneNumber;

                    var facultySubjectList = new List<FacultySubject>();
                    var facultySubjectExistList = await _context.FacultySubjects
                        .Where(fs => fs.FacultyID == faculty.ID).ToListAsync();
                    var facultySubjectIDExistList = facultySubjectExistList.Select(fs => fs.SubjectID).ToList();
                    var subjectIDs = req.SubjectIDs.Distinct<int>();

                    foreach (var subjectID in subjectIDs)
                    {
                        if (facultySubjectIDExistList.Contains(subjectID))
                        {
                            facultySubjectExistList = facultySubjectExistList
                                .Where(fs => fs.SubjectID != subjectID).ToList();
                            continue;
                        }

                        facultySubjectList.Add(new FacultySubject { SubjectID = subjectID, FacultyID = (int)faculty.ID });
                    }

                    if (facultySubjectExistList.Count > 0)
                    {
                        _context.FacultySubjects.RemoveRange(facultySubjectExistList);
                    }

                    await _context.FacultySubjects.AddRangeAsync(facultySubjectList);
                    _context.Update(faculty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(req.ID))
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

        // GET: Faculties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties
                .FirstOrDefaultAsync(m => m.ID == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public List<FacultySelectDTO> Select2(string search, int subjectID, List<int> facultyExist)
        {
            try
            {
                search = string.IsNullOrEmpty(search) ? "" : search.ToLower();
                var faculties = _context.Faculties.Where(f => !facultyExist.Contains(f.ID)
                        && f.Name.ToLower().Contains(search) && f.Deleted != 1);

                if (subjectID > 0)
                {
                    return (from f in faculties
                            join fs in _context.FacultySubjects on f.ID equals fs.FacultyID into m
                            from fs in m.DefaultIfEmpty()
                            where fs.SubjectID == subjectID
                            select new FacultySelectDTO { ID = f.ID, Name = f.Name }).ToList();
                }

                return (from f in faculties
                        select new FacultySelectDTO { ID = f.ID, Name = f.Name }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool FacultyExists(int? id)
        {
            return _context.Faculties.Any(e => e.ID == id);
        }
    }
}
