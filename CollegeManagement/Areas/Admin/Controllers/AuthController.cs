using CollegeManagement.DTO.Account;
using CollegeManagement.Helper;
using CollegeManagement.Middleware;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : BaseController
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (UserLogin != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AuthenticateRequest req)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _context.Users
                        .FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(req.UserName.ToLower()) && u.Deleted != 1);

                    if (user == null)
                    {
                        TempData["Error"] = "Wrong username or password";
                        return RedirectToAction("Index");
                    }

                    if (!verifyPassword(req.Password, user.Password))
                    {
                        TempData["Error"] = "Wrong username or password";
                        return RedirectToAction("Index");
                    }

                    var jwtToken = generateJwtToken(user);

                    var response = new AuthenticateResponse
                    {
                        FullName = user.FullName,
                        Id = user.ID,
                        UserName = user.UserName,
                        Token = jwtToken,
                    };

                    if (response != null)
                    {
                        setTokenCookie(response.Token);
                        TempData["Success"] = MESSAGE_SUCCESS;
                        return RedirectToAction("Index", "Home");
                    }

                    TempData["Error"] = "Something wrong";
                    return RedirectToAction("Index");
                }

                return View(req);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddYears(3)
            };
            Response.Cookies.Append("collegeusertoken", token, cookieOptions);
        }

        private bool verifyPassword(string password, string dbPassword)
        {
            //string hashPass = this.hashPassword(password);
            string hassMd5Pass = this.CreateMD5Hash(password);
            return hassMd5Pass.SequenceEqual(dbPassword);
        }

        public string CreateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public IActionResult Logout(AuthenticateRequest req)
        {
            Response.Cookies.Delete("collegeusertoken");
            return RedirectToAction("Index");
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtMiddleware.SECRET_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserID", user.ID.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [Authorize]
        public IActionResult MyProfile()
        {
            try
            {
                if (UserLogin.ID > 0)
                {
                    var res = new AccountUpSertDTO
                    {
                        Address = UserLogin.Address,
                        Email = UserLogin.Email,
                        FullName = UserLogin.FullName,
                        ImageURL = UserLogin.ImageURL,
                        Password = UserLogin.Password,
                        PhoneNumber = UserLogin.Phone,
                        UserName = UserLogin.UserName,
                    };
                    return View(res);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditMyProfile(AccountUpSertDTO req)
        {
            try
            {
                if (UserLogin.ID > 0)
                {
                    var user = _context.Users.FirstOrDefault(u => u.Deleted != 1 && u.ID == UserLogin.ID);
                    if (user == null)
                    {
                        TempData["Error"] = "Authentication failed";
                        return RedirectToAction(nameof(Logout));
                    }
                    
                    if (user.Role.Equals(ConstantVariables.ROLE_FACULTY))
                    {
                        var faculty = _context.Faculties.FirstOrDefault(f => f.Deleted != 1 && f.UserID == user.ID);

                        if (faculty == null)
                        {
                            TempData["Error"] = "Authentication failed";
                            return RedirectToAction(nameof(Logout));
                        }

                        var imgPath = await Utils.SaveFile(req.Image, "Faculty");

                        faculty.Address = req.Address;
                        faculty.Email = req.Email;
                        faculty.Name = req.FullName;
                        faculty.ImageUrl = imgPath ?? faculty.ImageUrl;
                        faculty.PhoneNumber = req.PhoneNumber;
                        _context.Faculties.Update(faculty);
                    }
                    else if (user.Role.Equals(ConstantVariables.ROLE_STUDENT))
                    {
                        var std = _context.Students.FirstOrDefault(f => f.Deleted != 1 && f.UserID == user.ID);

                        if (std == null)
                        {
                            TempData["Error"] = "Authentication failed";
                            return RedirectToAction(nameof(Logout));
                        }

                        var imgPath = await Utils.SaveFile(req.Image, "Student");

                        std.PermanentAddress = req.Address;
                        std.Email = req.Email;
                        std.Name = req.FullName;
                        std.ImageURL = imgPath ?? std.ImageURL;
                        std.PhoneNumber = req.PhoneNumber;
                        _context.Students.Update(std);
                    }
                    else
                    {
                        var imgPath = await Utils.SaveFile(req.Image, "Users");

                        user.Address = req.Address;
                        user.Email = req.Email;
                        user.FullName = req.FullName;
                        user.ImageURL = imgPath ?? user.ImageURL;
                        user.PhoneNumber = req.PhoneNumber;
                        _context.Users.Update(user);
                    }

                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Update profile successfully";
                    return RedirectToAction(nameof(MyProfile));
                }
                return RedirectToAction(nameof(MyProfile), req);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize(RoleType = "SuperAdmin, Admin")]
        public IActionResult List()
        {
            return View();
        }

        [Authorize(RoleType = "SuperAdmin, Admin")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var data = new List<User>();

                switch (UserLogin.Role)
                {
                    case ConstantVariables.ROLE_SUPER_ADMIN:
                        return Json(new
                        {
                            status = true,
                            msg = MESSAGE_SUCCESS,
                            data = from u in _context.Users
                                   join f in _context.Faculties on u.ID equals f.UserID
                                   into q from f in q.DefaultIfEmpty()
                                   join s in _context.Students on u.ID equals s.UserID
                                   into p from s in p.DefaultIfEmpty()
                                   where u.Deleted != 1 && u.ID != UserLogin.ID
                                   orderby u.UpdatedAt descending
                                   select new User
                                   {
                                       ID = u.ID,
                                       FullName = f != null ? f.Name : s != null ? s.Name: u.FullName,
                                       Address = f != null ? f.Address : s != null ? s.PermanentAddress : u.Address,
                                       Email = f != null ? f.Email : s != null ? s.Email : u.Email,
                                       PhoneNumber = f != null ? f.PhoneNumber : s != null ? s.PhoneNumber : u.PhoneNumber,
                                       ImageURL = f != null ? f.ImageUrl : s != null ? s.ImageURL : u.ImageURL,
                                       Role = u.Role,
                                       UserName = u.UserName,
                                   }
                        });
                    case ConstantVariables.ROLE_ADMIN:
                        return Json(new
                        {
                            status = true,
                            msg = MESSAGE_SUCCESS,
                            data = from u in _context.Users
                                   join f in _context.Faculties on u.ID equals f.UserID
                                   into q
                                   from f in q.DefaultIfEmpty()
                                   join s in _context.Students on u.ID equals s.UserID
                                   into p
                                   from s in p.DefaultIfEmpty()
                                   where u.Deleted != 1 && u.ID != UserLogin.ID && 
                                        !u.Role.Equals(ConstantVariables.ROLE_SUPER_ADMIN)
                                   orderby u.UpdatedAt descending
                                   select new User
                                   {
                                       ID = u.ID,
                                       FullName = f != null ? f.Name : s != null ? s.Name : u.FullName,
                                       Address = f != null ? f.Address : s != null ? s.PermanentAddress : u.Address,
                                       Email = f != null ? f.Email : s != null ? s.Email : u.Email,
                                       PhoneNumber = f != null ? f.PhoneNumber : s != null ? s.PhoneNumber : u.PhoneNumber,
                                       ImageURL = f != null ? f.ImageUrl : s != null ? s.ImageURL : u.ImageURL,
                                       Role = u.Role,
                                       UserName = u.UserName,
                                   }
                        });
                    default:
                        return Json(new
                        {
                            status = false,
                            msg = MESSAGE_SUCCESS,
                            data = new List<User>()
                        });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    msg = ex.Message,
                    data = new List<User>()
                });
            }
        }

        [HttpPost]
        [Authorize()]
        public IActionResult ChangePassword(AccountChangePass req)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Deleted != 1 && u.ID == UserLogin.ID);

                if (user == null)
                {
                    TempData["Error"] = "Authentication failed";
                    return RedirectToAction(nameof(Logout));
                }

                if (!verifyPassword(req.CurrentPassword, user.Password))
                {
                    TempData["Error"] = "Wrong current password";
                }
                else
                {
                    user.Password = CreateMD5Hash(req.NewPassword);
                    user.UpdatedAt = DateTime.Now;
                    _context.Users.Update(user);
                    Response.Cookies.Delete("collegeusertoken");
                    _context.SaveChanges();
                    setTokenCookie(generateJwtToken(user));
                    TempData["Success"] = "Update password successfully";
                    return RedirectToAction(nameof(MyProfile));
                }
                return View(req);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        [Authorize(RoleType = "SuperAdmin, Admin")]
        public IActionResult Create()
        {
            return View(new AccountUpSertDTO());
        }

        [Authorize(RoleType = "SuperAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(AccountUpSertDTO req)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _context.Users.FirstOrDefaultAsync(u => u.Deleted != 1 && u.UserName.ToUpper().Contains(req.UserName)) == null)
                    {
                        var user = new User();

                        var imgPath = await Utils.SaveFile(req.Image, "Users");
                        user.Address = req.Address;
                        user.Email = req.Email;
                        user.FullName = req.FullName;
                        user.ImageURL = imgPath;
                        user.Password = CreateMD5Hash(req.Password);
                        user.Role = req.Role;
                        user.UserName = req.UserName;
                        user.PhoneNumber = req.PhoneNumber;
                        user.CreatedAt = DateTime.Now;
                        user.UpdatedAt = DateTime.Now;

                        transaction.CreateSavepoint("BeforeAddUser");
                        _context.Add(user);
                        await _context.SaveChangesAsync();

                        if (req.Role == req.UserRole[1])
                        {
                            var faculty = await _context.Faculties
                                .FirstOrDefaultAsync(f => f.ID == req.TargetID && f.Deleted != 1
                                    && (f.UserID == null || f.UserID == 0)
                                );
                            if (faculty == null)
                            {
                                transaction.RollbackToSavepoint("BeforeAddUser");
                                TempData["Error"] = "Faculty was deleted or already has account or not exist";
                                return View(req);
                            }
                            faculty.UserID = user.ID;
                            _context.Faculties.Update(faculty);
                            await _context.SaveChangesAsync();
                        }
                        else if (req.Role == req.UserRole[2])
                        {
                            var student = await _context.Students
                                .FirstOrDefaultAsync(f => f.ID == req.TargetID && f.Deleted != 1
                                    && (f.UserID == null || f.UserID == 0) && f.Status == 1
                                );

                            if (student == null)
                            {
                                transaction.RollbackToSavepoint("BeforeAddUser");
                                TempData["Error"] = "Student was deleted or already has account or not exist or not addmission";
                                return View(req);
                            }

                            student.UserID = user.ID;
                            _context.Students.Update(student);
                            await _context.SaveChangesAsync();
                        }

                        TempData["Success"] = MESSAGE_SUCCESS;
                        await transaction.CommitAsync();
                        return RedirectToAction(nameof(List));
                    }
                    TempData["Error"] = "Username is already exist";
                    return View(req);
                }
                return View(req);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                TempData["Error"] = ex.Message;
                return View(req);
            }
        }

        [Authorize(RoleType = "SuperAdmin, Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.ID == id && u.Deleted != 1);
                if (user == null)
                {
                    return Json(new { status = false, message = MESSAGE_NOT_DELETE });
                }
                else
                {
                    if (user.Role == "Faculty")
                    {
                        var faculty = await _context.Faculties.FirstOrDefaultAsync(f => f.Deleted != 1 && f.UserID == user.ID );
                        if (faculty != null)
                        {
                            faculty.UserID = null;
                            _context.Update(faculty);
                        }
                    }
                    else if (user.Role == "Student")
                    {
                        var student = await _context.Students.FirstOrDefaultAsync(f => f.Deleted != 1 && f.UserID == user.ID);
                        if (student != null)
                        {
                            student.UserID = null;
                            _context.Update(student);
                        }
                    }
                    user.Deleted = 1;
                    _context.Update(user);
                    _context.SaveChanges();
                    return Json(new { status = true, message = MESSAGE_DELETE_SUCCESS });
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
    }
}
