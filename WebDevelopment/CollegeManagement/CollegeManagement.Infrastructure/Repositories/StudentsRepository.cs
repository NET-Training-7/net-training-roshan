using CollegeManagement.Infrastructure.Repositories.Interfaces;
using CollegeManagement.Web.data;
using CollegeManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Infrastructure.Repositories;
public class StudentRepository : IStudentRepository
{
    private readonly CollegeDbContext db;

    public StudentRepository(CollegeDbContext _db)
    {
        db = _db;
    }

    public async Task<List<Student>> GetAll(string searchText = "")
    {
        try
        {
            List<Student> students = new();

            if (searchText == "")
                students = await db.Students.ToListAsync();
            else
                students = await db.Students.Where(x => x.Name.Contains(searchText) ||
                            x.Address.Contains(searchText)).ToListAsync();
            return students;
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to connect to db. Error: {ex.Message}");
        }
    }

    public async ValueTask<Student> Get(int id)
    {
        var student = await db.Students.FindAsync(id);
        return student;
    }

    public async Task Insert(Student student)
    {
        await db.Students.AddAsync(student);
        await db.SaveChangesAsync();
    }

    public async Task Edit(Student student)
    {
        db.Students.Update(student);
        await db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await db.Students.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}






//using CollegeManagement.Web.data;
//using CollegeManagement.Web.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CollegeManagement.Infrastructure.Repositories
//{
//    public class StudentsRepository
//    {
//        private readonly CollegeDbContext db;
//        public StudentsRepository(CollegeDbContext _db)
//        {
//            db = _db;
//        }

//        public async Task<List<Student>> GetAll(string searchText)
//        {
//            List<Student> students = new();
//            if (searchText == "")
//                students = await db.Students.ToListAsync();
//            else
//                students = await db.Students.Where(x => x.Name.Contains(searchText) || x.Address.Contains(searchText)).ToListAsync();
//            return students;
//        }
//    }
//}
