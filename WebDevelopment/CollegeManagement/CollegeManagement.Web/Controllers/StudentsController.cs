﻿using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using CollegeManagement.Web.Extensions;
using CollegeManagement.Web.ViewModels;
using CollegeManagement.Web.Mappers;
using CollegeManagement.Infrastructure.Repositories;
using CollegeManagement.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CollegeManagement.Web.Controllers;

[Authorize(Roles = "Admin")]
public class StudentsController : Controller
{
    private readonly IStudentRepository studentsRepository;
    private readonly MajorsRepository majorsRepository;

    public StudentsController(IStudentRepository _studentsRepository, MajorsRepository majorsRepository)
    {
        studentsRepository = _studentsRepository;
        this.majorsRepository = majorsRepository;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(string searchText = "")
    {
        try
        {
            var students = await studentsRepository.GetAll(searchText);
            var studentViewModels = students.ToViewModel();

            return View(studentViewModels);
        }
        catch (Exception ex)
        {
            return View(ex);
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        var student = await studentsRepository.Get(id);// select * from Students where Id = id
        var studentViewModel = student.ToViewModel();
        return View(studentViewModel);
    }

    public async Task<IActionResult> Add()
    {
        var majorsList = await majorsRepository.GetAll();
        var majors = majorsList.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        ViewData["Majors"] = majors;

        return View();
    }

    [HttpPost]
    public IActionResult Add(StudentViewModel studentVM)
    {
        if (studentVM == null || !ModelState.IsValid)
            return View("Error", new ErrorViewModel { RequestId = "Register Student" });

        string avatarPath = studentVM.Avatar.SaveProfileImage();

        var student = studentVM.ToModel();

        student.AvatarPath = avatarPath;

        studentsRepository.Insert(student);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var student = await studentsRepository.Get(id);
        return View(student.ToViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Edit(StudentViewModel studentVM)
    {
        if (studentVM == null || !ModelState.IsValid)
            return View("Error", new ErrorViewModel { RequestId = "Update Student" });

        var student = studentVM.ToModel();

        if (studentVM.Avatar is not null)
        {
            var path = studentVM.Avatar.SaveProfileImage();
            student.AvatarPath = path;
        }

        await studentsRepository.Edit(student);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteConfirm(int id)
    {
        var student = await studentsRepository.Get(id);
        return View(student);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Student student)
    {
        await studentsRepository.Delete(student.Id);

        return RedirectToAction("Index");
    }
}





//using Microsoft.AspNetCore.Mvc;
//using CollegeManagement.Web.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using CollegeManagement.Web.Extensions;
//using CollegeManagement.Web.ViewModels;
//using CollegeManagement.Web.Mappers;
//using CollegeManagement.Infrastructure.Repositories;
//using CollegeManagement.Infrastructure.Repositories.Interfaces;
//using Microsoft.AspNetCore.Authorization;

//namespace CollegeManagement.Web.Controllers;
//[Authorize]
//public class StudentsController : Controller
//{
//    private readonly IStudentRepository studentsRepository;
//    private readonly MajorsRepository majorsRepository;

//    public StudentsController(IStudentRepository _studentsRepository, MajorsRepository majorsRepository)
//    {
//        studentsRepository = _studentsRepository;
//        this.majorsRepository = majorsRepository;
//    }
//    [AllowAnonymous]
//    public async Task<IActionResult> Index(string searchText = "")
//    {
//        try
//        {
//            var students = await studentsRepository.GetAll(searchText);
//            var studentViewModels = students.ToViewModel();

//            return View(studentViewModels);
//        }
//        catch (Exception ex)
//        {
//            return View(ex);
//        }
//    }

//    public async Task<IActionResult> Details(int id)
//    {
//        var student = await studentsRepository.Get(id);// select * from Students where Id = id
//        var studentViewModel = student.ToViewModel();
//        return View(studentViewModel);
//    }

//    public async Task<IActionResult> Add()
//    {
//        var majorsList = await majorsRepository.GetAll();
//        var majors = majorsList.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
//        ViewData["Majors"] = majors;

//        return View();
//    }

//    [HttpPost]
//    public IActionResult Add(StudentViewModel studentVM)
//    {
//        if (studentVM == null || !ModelState.IsValid)
//            return View("Error", new ErrorViewModel { RequestId = "Register Student" });

//        string avatarPath = studentVM.Avatar.SaveProfileImage();

//        var student = studentVM.ToModel();

//        student.AvatarPath = avatarPath;

//        studentsRepository.Insert(student);

//        return RedirectToAction("Index");
//    }

//    public async Task<IActionResult> Edit(int id)
//    {
//        var student = await studentsRepository.Get(id);
//        return View(student.ToViewModel());
//    }

//    [HttpPost]
//    public async Task<IActionResult> Edit(StudentViewModel studentVM)
//    {
//        if (studentVM == null || !ModelState.IsValid)
//            return View("Error", new ErrorViewModel { RequestId = "Update Student" });

//        var student = studentVM.ToModel();

//        if (studentVM.Avatar is not null)
//        {
//            var path = studentVM.Avatar.SaveProfileImage();
//            student.AvatarPath = path;
//        }

//        await studentsRepository.Edit(student);

//        return RedirectToAction("Index");
//    }

//    public async Task<IActionResult> DeleteConfirm(int id)
//    {
//        var student = await studentsRepository.Get(id);
//        return View(student);
//    }

//    [HttpPost]
//    public async Task<IActionResult> Delete(Student student)
//    {
//        await studentsRepository.Delete(student.Id);

//        return RedirectToAction("Index");
//    }
//}





//using Microsoft.AspNetCore.Mvc;
//using CollegeManagement.Web.Models;
//using CollegeManagement.Web.data;
//using F = System.IO.File;
//using CollegeManagement.Web.Extensions;
//using Microsoft.EntityFrameworkCore;
//using CollegeManagement.Web.ViewModels;
//using CollegeManagement.Web.Mappers;
//using CollegeManagement.Infrastructure.Repositories;

//namespace CollegeManagement.Web.Controllers
//{
//    public class StudentsController : Controller
//    {
//        private readonly CollegeDbContext db;
//        private readonly StudentsRepository studentsRepository;

//        public StudentsController(CollegeDbContext _db, StudentsRepository _studentsRepository)
//        {
//            db = _db;
//            studentsRepository = _studentsRepository;
//        }

//        //async
//        public async Task<IActionResult> Index(string searchText = "")
//        {
//            var students = await studentsRepository.GetAll(searchText);
//            var studentsViewModels = students.ToViewModel();
//            return View(studentsViewModels);    
//        }
//        //public IActionResult Index()
//        //{
//        //
//        //    var students = db.students.ToList();
//        //    var studentViewModels = students.ToViewModel();
//        //    return View(studentViewModels);
//        //}

//        public IActionResult Details(int id)
//        {
//            var student = db.Students.Find(id);
//            return View(student.ToViewModel());
//        }

//        public IActionResult Add()
//        {
//            return View();

//        }

//        [HttpPost]
//        public IActionResult Add(StudentViewModel studentVM)
//        {
//            if (studentVM == null || !ModelState.IsValid)
//                return View("Error", new ErrorViewModel { RequestId = "Register Student" });
//            //var avatarPath = FormImageHelper.SaveProfileImage(student.Avatar!);
//            var avatarPath = studentVM.Avatar.SaveProfileImage();


//            var student = studentVM.ToModel();
//            student.AvatarPath = avatarPath;
//            db.Students.Add(student);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int id)
//        {
//            var student = db.Students.Find(id);
//            return View(student.ToViewModel());

//        }

//        [HttpPost]
//        public IActionResult Edit(StudentViewModel studentVM)
//        {
//            if (studentVM == null || !ModelState.IsValid)
//                return View("Error", new ErrorViewModel { RequestId = "Update Student" });

//            var student = studentVM.ToModel();
//            if (studentVM.Avatar != null)
//            {
//                //var path = FormImageHelper.SaveProfileImage(student.Avatar);
//                var path = studentVM.Avatar.SaveProfileImage();
//                student.AvatarPath = path;
//            }
//            db.Students.Update(student);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        public IActionResult DeleteConfirm(int id)
//        {
//            var student = db.Students.Find(id);
//            return View(student);
//        }

//        [HttpPost]
//        public IActionResult Delete(Student student)
//        {
//            db.Students.Remove(student);
//            db.SaveChanges();

//            return RedirectToAction("Index");
//        }


//    }
//}

