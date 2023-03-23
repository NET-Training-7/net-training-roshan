using CollegeManagement.Web.data;
using CollegeManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Web.Controllers;
public class MajorsController : Controller
{
    private readonly CollegeDbContext db;

    public MajorsController(CollegeDbContext _db)
    {
        db = _db;
    }

    public ActionResult Index()
    {
        var majors = db.Majors.ToList();
        return View(majors);
    }

    public ActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Add(Major major)
    {
        try
        {
            db.Majors.Add(major);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Edit(int id)
    {
        var majors= db.Majors.Find(id);
        return View(majors);
    }

    [HttpPost]
    public ActionResult Edit(Major major)
    {
        try
        {
            db.Majors.Update(major);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    public ActionResult DeleteConfirm(int id)
    {
        var majors = db.Majors.Find(id);
        return View(majors);

    }

    [HttpPost]
    public ActionResult Delete(Major major)
    {
        try
        {
            db.Majors.Remove(major);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}

