using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() //
        {
            return View();
        }
        
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult FeedBack()
        {
            return View();
        }
        public IActionResult Teacher()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Departments()
        {
            return View();
        }
        public IActionResult Facilities()
        {
            return View();
        }


    }
}