using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Helper;
using CollegeManagement.Models;
using CollegeManagement.DTO.Markses;
using CollegeManagement.DTO.Subject;
using System.Text.Json;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [Route("Admin/Marks/{action=Index}/{courseId?}/{subjectId?}")]
    public class MarksController : BaseController
    {
        private readonly DataContext _context;

        public MarksController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Marks
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            switch (UserLogin.Role)
            {
                case ConstantVariables.ROLE_FACULTY:
                    var faculty = _context.Faculties.FirstOrDefault(f => f.Deleted != 1 && f.UserID == UserLogin.ID);

                    var data = from c in _context.Courses
                               join cs in _context.CourseSubjects on c.ID equals cs.CourseID
                               into q
                               from cs in q.DefaultIfEmpty()
                               join s in _context.Subjects on cs.SubjectID equals s.ID
                               into p
                               from s in p.DefaultIfEmpty()
                               where c.Status == 1 && c.Deleted != 1 && s.Deleted != 1 && cs.FacultyID == faculty.ID
                               select new MarksListDTO
                               {
                                   CourseID = c.ID,
                                   CourseName = c.Name,
                                   SubjectID = s.ID,
                                   SubjectName = s.Name
                               };
                    return Json(new { data = await data.ToListAsync() });

                case ConstantVariables.ROLE_STUDENT:
                    var student = _context.Students.FirstOrDefault(f => f.Deleted != 1 && f.UserID == UserLogin.ID);

                    data = from c in _context.Courses
                               join cs in _context.CourseSubjects on c.ID equals cs.CourseID
                               into q
                               from cs in q.DefaultIfEmpty()
                               join s in _context.Subjects on cs.SubjectID equals s.ID
                               into p
                               from s in p.DefaultIfEmpty()
                               where c.Status == 1 && c.Deleted != 1 && s.Deleted != 1 && student.CourseID == c.ID
                               select new MarksListDTO
                               {
                                   CourseID = c.ID,
                                   CourseName = c.Name,
                                   SubjectID = s.ID,
                                   SubjectName = s.Name
                               };
                    return Json(new { data = await data.ToListAsync() });

                default:
                    data = from c in _context.Courses
                           join cs in _context.CourseSubjects on c.ID equals cs.CourseID
                           into q
                           from cs in q.DefaultIfEmpty()
                           join s in _context.Subjects on cs.SubjectID equals s.ID
                           into p
                           from s in p.DefaultIfEmpty()
                           where c.Status == 1 && c.Deleted != 1 && s.Deleted != 1
                           select new MarksListDTO
                           {
                               CourseID = c.ID,
                               CourseName = c.Name,
                               SubjectID = s.ID,
                               SubjectName = s.Name
                           };
                    return Json(new { data = await data.ToListAsync() });
            }
        }

        // GET: Admin/Marks/Details/5
        public async Task<IActionResult> Details(int? courseId, int? subjectId)
        {
            if (courseId == null || subjectId == null)
            {
                TempData["Error"] = MESSAGE_NOT_FOUND;
                return RedirectToAction(nameof(Index));
            }
            var res = new MarksUpSertDTO();

            switch (UserLogin.Role)
            {
                case ConstantVariables.ROLE_FACULTY:
                    var faculty = _context.Faculties.FirstOrDefault(f => f.Deleted != 1 && f.UserID == UserLogin.ID);
                    if (_context.CourseSubjects.Any(cs => cs.CourseID == courseId && cs.SubjectID == subjectId && cs.FacultyID == faculty.ID))
                    {
                        res.Marks = await (from s in _context.Students
                                           join m in _context.Markses on s.ID equals m.StudentID
                                           into p
                                           from m in p.DefaultIfEmpty()
                                           join c in _context.Courses on s.CourseID equals c.ID
                                           into q
                                           from c in q.DefaultIfEmpty()
                                           where c.ID == courseId && s.Status == 1 && s.Deleted != 1
                                           select new MarksSelectDTO
                                           {
                                               StudentID = s.ID,
                                               StudentName = s.Name,
                                               Score = m.Score,
                                               Status = m.Status
                                           }).ToListAsync();
                        res.Subject = await (from s in _context.Subjects
                                             where s.ID == subjectId && s.Deleted != 1
                                             select new SubjectSelectDTO
                                             {
                                                 ID = s.ID,
                                                 Name = s.Name
                                             }).FirstOrDefaultAsync();
                    }
                    break;

                case ConstantVariables.ROLE_STUDENT:
                    var student = _context.Students.FirstOrDefault(f => f.Deleted != 1 && f.UserID == UserLogin.ID);

                    if (student.CourseID == courseId)
                    {
                        res.Marks = await (from s in _context.Students
                                           join m in _context.Markses on s.ID equals m.StudentID
                                           into p
                                           from m in p.DefaultIfEmpty()
                                           join c in _context.Courses on s.CourseID equals c.ID
                                           into q
                                           from c in q.DefaultIfEmpty()
                                           where c.ID == courseId && s.Status == 1 && s.Deleted != 1
                                           select new MarksSelectDTO
                                           {
                                               StudentID = s.ID,
                                               StudentName = s.Name,
                                               Score = m.Score,
                                               Status = m.Status
                                           }).ToListAsync();
                        res.Subject = await (from s in _context.Subjects
                                             where s.ID == subjectId && s.Deleted != 1
                                             select new SubjectSelectDTO
                                             {
                                                 ID = s.ID,
                                                 Name = s.Name
                                             }).FirstOrDefaultAsync();
                    }
                    break;

                default:
                    res.Marks = await (from s in _context.Students
                                       join m in _context.Markses on s.ID equals m.StudentID
                                       into p
                                       from m in p.DefaultIfEmpty()
                                       join c in _context.Courses on s.CourseID equals c.ID
                                       into q
                                       from c in q.DefaultIfEmpty()
                                       where c.ID == courseId && s.Status == 1 && s.Deleted != 1
                                       select new MarksSelectDTO
                                       {
                                           StudentID = s.ID,
                                           StudentName = s.Name,
                                           Score = m.Score,
                                           Status = m.Status
                                       }).ToListAsync();
                    res.Subject = await (from s in _context.Subjects
                                         where s.ID == subjectId && s.Deleted != 1
                                         select new SubjectSelectDTO
                                         {
                                             ID = s.ID,
                                             Name = s.Name
                                         }).FirstOrDefaultAsync();

                    break;
            }
            
            return View(res);
        }

        // GET: Admin/Marks/Edit/5
        [Authorize(RoleType = "SuperAdmin, Admin")]
        public async Task<IActionResult> Edit(int? courseId, int? subjectId)
        {
            if (courseId == null || subjectId == null)
            {
                TempData["Error"] = MESSAGE_NOT_FOUND;
                return RedirectToAction(nameof(Index));
            }
            var res = new MarksUpSertDTO
            {
                Marks = await (from s in _context.Students
                                join m in _context.Markses on s.ID equals m.StudentID
                                into p from m in p.DefaultIfEmpty()
                                join c in _context.Courses on s.CourseID equals c.ID
                                into q
                                from c in q.DefaultIfEmpty()
                                where c.ID == courseId && s.Status == 1 && s.Deleted != 1
                                select new MarksSelectDTO
                                {
                                    StudentID = s.ID,
                                    StudentName = s.Name,
                                    Score = m.Score,
                                    Status = m.Status
                                }).ToListAsync(),
                Subject = await (from s in _context.Subjects
                                 where s.ID == subjectId && s.Deleted != 1
                                 select new SubjectSelectDTO
                                 {
                                     ID = s.ID,
                                     Name = s.Name
                                 }).FirstOrDefaultAsync(),
                CourseID = courseId,
                SubjectID = subjectId
            };
            return View(res);
        }

        // POST: Admin/Marks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(RoleType = "SuperAdmin, Admin")]
        public async Task<ActionResult> EditMark(MarksUpSertDTO req)
        {
            try
            {
                var markses = JsonSerializer.Deserialize<List<Marks>>(req.MarkJson);
                var markExistList = await(from m in _context.Markses
                              join s in _context.Students on m.StudentID equals s.ID
                              into p
                              from s in p.DefaultIfEmpty()
                              join c in _context.Courses on s.CourseID equals c.ID
                              into q
                              from c in q.DefaultIfEmpty()
                              where c.ID == req.CourseID && m.SubjectID == req.SubjectID
                              select m).ToListAsync();

                if (markExistList.Count == 0)
                {
                    foreach (var m in markses)
                    {
                        m.SubjectID = req.SubjectID;
                        if (m.Score != null && m.Score >= 8)
                        {
                            m.Status = 1;
                        }
                        else if (m.Score != null && m.Score < 8)
                        {
                            m.Status = 0;
                        }
                    }
                    await _context.AddRangeAsync(markses);
                }
                else
                {
                    var newMarks = new List<Marks>();
                    foreach (var m in markses)
                    {
                        var marksExist = markExistList.FirstOrDefault(d => d.StudentID == m.StudentID);
                        if (marksExist != null)
                        {
                            marksExist.Score = m.Score;
                            if (m.Score != null && m.Score >= 8)
                            {
                                marksExist.Status = 1;
                            }
                            else if (m.Score != null && m.Score < 8)
                            {
                                marksExist.Status = 0;
                            }
                            _context.Update(marksExist);
                        }
                        else
                        {
                            m.SubjectID = req.SubjectID;
                            if (m.Score != null && m.Score >= 8)
                            {
                                m.Status = 1;
                            }
                            else if (m.Score != null && m.Score < 8)
                            {
                                m.Status = 0;
                            }

                            newMarks.Add(m);
                        }
                    }
                    await _context.AddRangeAsync(newMarks);
                }
                await _context.SaveChangesAsync();
                return Json(new { status = true, message = MESSAGE_SUCCESS });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        private bool MarksExists(int id)
        {
            return _context.Markses.Any(e => e.ID == id);
        }
    }
}
