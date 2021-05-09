﻿using System;
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
using CollegeManagement.DTO.Faculty;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CourseController : BaseController
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Course
        public IActionResult Index()
        {
            return View();
        }

        // GET: Admin/Course
        public async Task<IActionResult> List()
        {
            try
            {
                var data = await (from c in _context.Courses
                            join d in _context.Departments on c.DepartmentID equals d.ID
                            into d
                            from ds in d.DefaultIfEmpty()
                            where c.Deleted != 1
                            orderby c.UpdatedAt descending
                            select new
                            {
                                ID = c.ID,
                                Name = c.Name,
                                Info = c.Info,
                                Price = c.Price,
                                Focus = c.Focus,
                                DepartmentName = ds.Name,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,
                                ImageURL = c.ImageURL,
                                CreatedAt = c.CreatedAt,
                                UpdatedAt = c.UpdatedAt,
                            }).ToListAsync();
                return Json(new
                {
                    status = true,
                    msg = MESSAGE_SUCCESS,
                    data = data
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    msg = ex.Message,
                    data = new List<Course>()
                });
            }
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
                var imgPath  = await Utils.SaveFile(req.Image, "Course");

                var course = new Course
                {
                    DepartmentID = req.DepartmentID,
                    Focus = req.Focus,
                    ImageURL = imgPath,
                    Name = req.Name,
                    StartDate = req.StartDate,
                    EndDate = req.EndDate,
                    Info = req.Info,
                    Price = req.Price,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                };

                _context.Add(course);
                await _context.SaveChangesAsync();

                var subjectList = JsonSerializer.Deserialize<List<CourseSubject>>(req.Subjects);
                foreach (var s in subjectList)
                {
                    if (s.SubjectID > 0)
                    {
                        s.CourseID = course.ID;
                    }
                }

                await _context.CourseSubjects.AddRangeAsync(subjectList);
                await _context.SaveChangesAsync();

                return Json(new { status = true, msg = MESSAGE_SUCCESS });
            }

            return Json(new { status = false, msg = MESSAGE_NOT_CREATE });
        }

        // GET: Admin/Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(d => d.ID == id && d.Deleted != 1);
            if (course == null)
            {
                return NotFound();
            }

            var res = new CourseUpSertDTO 
            {
                ID = course.ID,
                DepartmentID = course.DepartmentID,
                Focus = course.Focus,
                ImageURL = course.ImageURL,
                Info = course.Info,
                Name = course.Name,
                Price = course.Price,
                EndDate = course.EndDate,
                StartDate = course.StartDate,
            };

            res.SubjectList = from cs in _context.CourseSubjects
                              join s in _context.Subjects on cs.SubjectID equals s.ID
                              into s
                              from ms in s.DefaultIfEmpty()
                              join f in _context.Faculties on cs.FacultyID equals f.ID
                              into f
                              from cf in f.DefaultIfEmpty()
                              where cs.CourseID == course.ID
                              select new CourseSubject
                              {
                                  ID = cs.ID,
                                  SubjectID = cs.SubjectID,
                                  FacultyID = cs.FacultyID,
                                  Subject = ms,
                                  Faculty = cf,
                                  CourseID = cs.CourseID
                              };

            res.DepartmentList = _context.Departments.Where(d => d.Deleted != 1)
                .OrderByDescending(d => d.UpdatedAt)
                .Select(d => new DepartmentSelectDTO
                {
                    ID = (int)d.ID,
                    Name = d.Name
                });

            return View(res);
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

                    var course = await _context.Courses.
                        FirstOrDefaultAsync(c => c.ID == id && c.Deleted != 1);

                    course.DepartmentID = req.DepartmentID;
                    course.Focus = req.Focus;
                    course.ImageURL = string.IsNullOrEmpty(imgPath) ? course.ImageURL: imgPath;
                    course.Name = req.Name;
                    course.Info = req.Info;
                    course.Price = req.Price;
                    course.EndDate = req.EndDate;
                    course.StartDate = req.StartDate;
                    course.UpdatedAt = DateTime.Now;

                    var courseSubjectList = new List<CourseSubject>();
                    var courseSubjectExistList = await _context.CourseSubjects
                        .Where(cs => cs.CourseID == course.ID).ToListAsync();

                    var courseSubjectIDExistList = courseSubjectExistList.Select(cs => cs.SubjectID).ToList();
                    var subjectList = JsonSerializer.Deserialize<List<CourseSubject>>(req.Subjects);

                    foreach (var s in subjectList)
                    {
                        if (s.SubjectID > 0 && courseSubjectIDExistList.Contains(s.SubjectID))
                        {
                            var subject = courseSubjectExistList
                                .FirstOrDefault(cs => cs.SubjectID == s.SubjectID);

                            if (subject.FacultyID != s.FacultyID)
                            {
                                subject.FacultyID = s.FacultyID;
                                _context.CourseSubjects.Update(subject);
                            }

                            courseSubjectExistList = courseSubjectExistList
                                .Where(cs => cs.SubjectID != s.SubjectID).ToList();
                        }
                        else if (s.SubjectID > 0)
                        {
                            courseSubjectList.Add(new CourseSubject {
                                SubjectID = s.SubjectID,
                                FacultyID = s.FacultyID,
                                CourseID = course.ID
                            });
                        }
                    }

                    if (courseSubjectExistList.Count > 0)
                    {
                        _context.CourseSubjects.RemoveRange(courseSubjectExistList);
                    }

                    await _context.CourseSubjects.AddRangeAsync(courseSubjectList);
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                    return Json(new { status = true, msg = MESSAGE_SUCCESS });
                }
                catch (Exception ex)
                {
                    if (!CourseExists(id))
                    {
                        return Json(new { status = false, msg = "This course is not exist"});
                    }
                    else
                    {
                        return Json(new { status = false, msg = ex.Message });
                        throw;
                    }
                }
                return Json(new { status = false, msg = MESSAGE_NOT_UPDATE });
            }

            return Json(new { status = false, msg = MESSAGE_NOT_UPDATE });
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
