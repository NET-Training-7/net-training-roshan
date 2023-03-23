using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Web.Models;
using CollegeManagement.Web.data;
using F = System.IO.File;
using CollegeManagement.Web.Extensions;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Web.ViewModels;
using CollegeManagement.Web.Mappers;

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
            var studentViewModels = students.ToViewModel();
            return View(studentViewModels);
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
        public IActionResult Add(StudentViewModel studentVM)
        {
            if (studentVM == null || !ModelState.IsValid)
                return View("Error", new ErrorViewModel { RequestId = "Register Student" });
            //var avatarPath = FormImageHelper.SaveProfileImage(student.Avatar!);
            var avatarPath = studentVM.Avatar.SaveProfileImage();


            var student = studentVM.ToModel();
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
        public IActionResult Edit(StudentViewModel studentVM)
        {
            if (studentVM == null || !ModelState.IsValid)
                return View("Error", new ErrorViewModel { RequestId = "Update Student" });

            var student = studentVM.ToModel();
            if (studentVM.Avatar != null)
            {
                //var path = FormImageHelper.SaveProfileImage(student.Avatar);
                var path = studentVM.Avatar.SaveProfileImage();
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

