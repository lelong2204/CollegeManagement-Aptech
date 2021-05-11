using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ErrorController : BaseController
    {
        // GET: ErrorController
        [Route("/Admin/Unauthorized")]
        public ActionResult Error403()
        {
            return View();
        }
        [Route("/Admin/NotFound")]
        public ActionResult Error404()
        {
            return View();
        }
    }
}
