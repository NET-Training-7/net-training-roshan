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
        public async Task<IActionResult> Index(string searchText = "")
        {
            List<Student> students = new();
            if (searchText == "")
                students = await db.Students.ToListAsync();
            else
                students = await db.Students.Where(x => x.Name.Contains(searchText) || x.Address.Contains(searchText)).ToListAsync();
            var studentsViewModels = students.ToViewModel();
            return View(studentsViewModels);    
        }
        //public IActionResult Index()
        //{
        //
        //    var students = db.students.ToList();
        //    var studentViewModels = students.ToViewModel();
        //    return View(studentViewModels);
        //}

        public IActionResult Details(int id)
        {
            var student = db.Students.Find(id);
            return View(student.ToViewModel());
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
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            return View(student.ToViewModel());

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
            db.Students.Update(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteConfirm(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            db.Students.Remove(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}

