using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Web.Models;
using CollegeManagement.Web.data;
using F = System.IO.File;
using CollegeManagement.Web.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly CollegeDbContext db;
        public StudentsController(CollegeDbContext _db)
        {
            db = _db;
        }

        //async
        //public async Task<IActionResult> Index()
        //{
        //    var students = await db.students.ToListAsync();
        //    return View(students);
        //}
        public IActionResult Index()
        {

            var students = db.students.ToList();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = db.students.Find(id);
            return View(student);
        }

        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (student == null || !ModelState.IsValid)
                return View("Error", new ErrorViewModel { RequestId = "Register Student" });
            var avatarPath = FormImageHelper.SaveProfileImage(student.Avatar!);

            student.AvatarPath = avatarPath;
            db.students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = db.students.Find(id);
            return View(student);

        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (student == null || !ModelState.IsValid)
                return View("Error", new ErrorViewModel { RequestId = "Update Student" });

            if (student.Avatar != null)
            {
                var path = FormImageHelper.SaveProfileImage(student.Avatar);
                student.AvatarPath = path;
            }
            db.students.Update(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteConfirm(int id)
        {
            var student = db.students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            db.students.Remove(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}

