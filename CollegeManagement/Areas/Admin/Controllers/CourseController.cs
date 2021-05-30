using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using CollegeManagement.DTO.CourseDTO;
using CollegeManagement.DTO.DepartmentsDTO;
using System.Text.Json;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(RoleType = "Admin, SuperAdmin, Faculty")]
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
                if (UserLogin.Role == "Faculty")
                {
                    var data = await (from c in _context.Courses
                                      join cs in _context.CourseSubjects on c.ID equals cs.CourseID
                                      into p
                                      from cs in p.DefaultIfEmpty()
                                      join f in _context.Faculties on cs.FacultyID equals f.ID
                                      into q
                                      from f in q.DefaultIfEmpty()
                                      join d in _context.Departments on c.DepartmentID equals d.ID
                                      into d
                                      from ds in d.DefaultIfEmpty()
                                      where c.Deleted != 1 && f.UserID == UserLogin.ID && f.Deleted != 1
                                      orderby c.UpdatedAt descending
                                      select new
                                      {
                                          ID = c.ID,
                                          Name = c.Name,
                                          Info = c.Info,
                                          Price = c.Price,
                                          StudentNumber = c.StudentNumber,
                                          DepartmentName = ds.Name,
                                          StartDate = c.StartDate,
                                          EndDate = c.EndDate,
                                          ImageURL = c.ImageURL,
                                          CreatedAt = c.CreatedAt,
                                          UpdatedAt = c.UpdatedAt,
                                          Status = c.Status,
                                          StudentCount = c.Students.Count()
                                      }).ToListAsync();

                    return Json(new
                    {
                        status = true,
                        msg = MESSAGE_SUCCESS,
                        data = data
                    });
                }
                else
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
                                          StudentNumber = c.StudentNumber,
                                          DepartmentName = ds.Name,
                                          StartDate = c.StartDate,
                                          EndDate = c.EndDate,
                                          ImageURL = c.ImageURL,
                                          CreatedAt = c.CreatedAt,
                                          UpdatedAt = c.UpdatedAt,
                                          Status = c.Status,
                                          StudentCount = c.Students.Count()
                                      }).ToListAsync();

                    return Json(new
                    {
                        status = true,
                        msg = MESSAGE_SUCCESS,
                        data = data
                    });
                }
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
            try
            {
                if (id == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                var course = new Course();

                if (UserLogin.Role == "Faculty")
                {
                    course = await(from c in _context.Courses
                           join cs in _context.CourseSubjects on c.ID equals cs.CourseID
                           into q
                           from cs in q.DefaultIfEmpty()
                           join f in _context.Faculties on cs.FacultyID equals f.ID
                           into p
                           from f in p.DefaultIfEmpty()
                           where f.Deleted != 1 && f.UserID == UserLogin.ID
                           select c).FirstOrDefaultAsync(m => m.ID == id && m.Deleted != 1);
                }
                else
                {
                    course = await _context.Courses
                        .FirstOrDefaultAsync(m => m.ID == id && m.Deleted != 1);
                }

                if (course == null)
                {
                    TempData["Error"] = MESSAGE_NOT_FOUND;
                    return RedirectToAction(nameof(Index));
                }

                return View(course);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Admin/Course/Create
        [Authorize(RoleType = "Admin, SuperAdmin")]
        public IActionResult Create()
        {
            var res = new CourseUpSertDTO();
            try
            {
                res.DepartmentList = _context.Departments.Where(d => d.Deleted != 1)
                    .OrderByDescending(d => d.UpdatedAt)
                    .Select(d => new DepartmentSelectDTO
                    {
                        ID = (int)d.ID,
                        Name = d.Name
                    });

                return View(res);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(res);
            }
        }

        // POST: Admin/Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(RoleType = "Admin, SuperAdmin")]
        public async Task<IActionResult> Create(CourseUpSertDTO req)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imgPath = await Utils.SaveFile(req.Image, "Course");

                    if (_context.Courses.Any(c => c.Code.Equals(req.Code) && c.Deleted != 1))
                    {
                        return Json(new { status = false, msg = "This course code was exist" });
                    }

                    var course = new Course
                    {
                        DepartmentID = req.DepartmentID,
                        ImageURL = imgPath,
                        Name = req.Name,
                        StartDate = req.StartDate,
                        EndDate = req.EndDate,
                        Info = req.Info,
                        StudentNumber = req.StudentNumber,
                        Price = req.Price,
                        Status = 0,
                        Code = req.Code,
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
            catch (Exception ex)
            {
                return Json(new { status = false, msg = ex.Message });
            }
        }

        // GET: Admin/Course/Edit/5
        [Authorize(RoleType = "Admin, SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = "Course not found";
                    return RedirectToAction(nameof(Index));
                }

                var course = await _context.Courses
                    .FirstOrDefaultAsync(d => d.ID == id && d.Deleted != 1);
                if (course == null)
                {
                    TempData["Error"] = "Course not found";
                    return RedirectToAction(nameof(Index));
                }

                if (course.Status == 1)
                {
                    TempData["Error"] = "Course can't edit";
                    return RedirectToAction(nameof(Index));
                }

                var res = new CourseUpSertDTO
                {
                    ID = course.ID,
                    DepartmentID = course.DepartmentID,
                    ImageURL = course.ImageURL,
                    Info = course.Info,
                    StudentNumber = course.StudentNumber,
                    Name = course.Name,
                    Price = course.Price,
                    Code = course.Code,
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
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(RoleType = "Admin, SuperAdmin")]
        public async Task<IActionResult> Edit(int id, CourseUpSertDTO req)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var imgPath = await Utils.SaveFile(req.Image, "Faculty");

                    var course = await _context.Courses.
                        FirstOrDefaultAsync(c => c.ID == id && c.Deleted != 1);

                    if (course == null)
                    {
                        TempData["Error"] = "Course not found";
                        return RedirectToAction(nameof(Index));
                    }

                    if (course.Status == 1)
                    {
                        TempData["Error"] = "Course can't edit";
                        return RedirectToAction(nameof(Index));
                    }

                    course.DepartmentID = req.DepartmentID;
                    course.ImageURL = string.IsNullOrEmpty(imgPath) ? course.ImageURL: imgPath;
                    course.Name = req.Name;
                    course.Info = req.Info;
                    course.Price = req.Price;
                    course.EndDate = req.EndDate;
                    course.StudentNumber = req.StudentNumber;
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
            }

            return Json(new { status = false, msg = MESSAGE_NOT_UPDATE });
        }

        // GET: Admin/Course/Delete/5
        [Authorize(RoleType = "Admin, SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = "Course not found";
                    return RedirectToAction(nameof(Index));
                }

                var course = await _context.Courses
                    .FirstOrDefaultAsync(m => m.ID == id && m.Deleted != 1);
                if (course == null)
                {
                    TempData["Error"] = "Course not found";
                    return RedirectToAction(nameof(Index));
                }

                return View(course);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(RoleType = "Admin, SuperAdmin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var course = await _context.Courses.FirstOrDefaultAsync(c => c.ID == id && c.Deleted != 1);
                if (course == null)
                {
                    TempData["Error"] = "Course not found";
                    return RedirectToAction(nameof(Index));
                }
                course.Deleted = 1;
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                TempData["Error"] = MESSAGE_DELETE_SUCCESS;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(RoleType = "Admin, SuperAdmin")]
        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.ID == id && e.Deleted != 1);
        }

        [HttpPost, ActionName("UpdateCourseStatus")]
        [Authorize(RoleType = "Admin, SuperAdmin")]
        public async Task<IActionResult> UpdateCourseStatus(int id)
        {
            try
            {
                var course = await _context.Courses.FirstOrDefaultAsync(c => c.Deleted != 1 && c.Status != 1 && c.EndDate < DateTime.Now && c.ID == id);
                if (course == null)
                {
                    return Json(new { status = false, msg = "Course not found" });
                }
                if (_context.Students.Count(s => s.Deleted != 1 && s.CourseID == course.ID) <= course.StudentNumber)
                {
                    var stdList = _context.Students.Where(s => s.Deleted != 1 && s.CourseID == course.ID).ToList();
                    stdList.ForEach(s => s.Status = (int)Student.StudentStatus.Admission);
                    course.EntryPoint = stdList.Min(s => s.TestScore);
                }
                else
                {
                    var stdList = _context.Students.OrderByDescending(s => s.TestScore)
                        .Where(s => s.Deleted != 1 && s.CourseID == course.ID).Take((int)course.StudentNumber).ToList();
                    stdList.ForEach(s => s.Status = (int)Student.StudentStatus.Admission);

                    course.EntryPoint = stdList.Min(s => s.TestScore);
                    _context.Students.OrderByDescending(s => s.TestScore)
                        .Where(s => s.Deleted != 1 && s.CourseID == course.ID).Skip((int)course.StudentNumber).ToList()
                        .ForEach(s => s.Status = (int)Student.StudentStatus.Fail);
                }
                course.Status = 1;
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return Json(new { status = true, msg = "Update course status done" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, msg = ex.Message });
            }
        }
    }
}
