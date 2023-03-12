using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Web.Models;
using CollegeManagement.Web.data;

namespace CollegeManagement.Web.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            CollegeDbContext db = new CollegeDbContext();
            var students = db.students.ToList();
            return View(students);
        }
    }
        

       

        //public IActionResult Details(int id)
        //{
        //   var student= students.Where(x => x.RollNo == id).FirstOrDefault();
        //    return View(student);
        //}

      
    }

