using CollegeManagement.DTO.AccountDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Route("Admin/{controller=Home}/{action=Index}/{id?}")]
    public class BaseController : Controller
    {
        protected const string MESSAGE_SUCCESS = "Successful";
        protected const string MESSAGE_NOT_FOUND = "Data not found";
        protected const string MESSAGE_NOT_CREATE = "Data not create";
        protected const string MESSAGE_NOT_COPIED = "Data not copied";
        protected const string MESSAGE_NOT_UPDATE = "Data not update";
        protected const string MESSAGE_DELETE_SUCCESS = "Supplier deleted successfully";
        protected const string MESSAGE_NOT_DELETE = "Data delete unsuccessfully";
        protected const string MESSAGE_STOCK = "Qty is than stock!";
        protected const string MESSAGE_DUPLICATE = "This template is already exist";
        protected const string MESSAGE_EMPTY = "Data cannot be empty";

        protected AccountLogin UserLogin => (AccountLogin)HttpContext.Items["UserLogin"];
    }
}
