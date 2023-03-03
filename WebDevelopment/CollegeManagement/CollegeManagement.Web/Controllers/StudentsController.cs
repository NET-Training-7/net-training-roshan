using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Web.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            // Render all students 
            return View();
        }
    }
}
