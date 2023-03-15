﻿using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Web.Models;
using CollegeManagement.Web.data;

namespace CollegeManagement.Web.Controllers
{
    public class StudentsController : Controller
    {
        CollegeDbContext db = new CollegeDbContext();
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
                return View("Error", new ErrorViewModel {  RequestId = "Register Student"});
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

