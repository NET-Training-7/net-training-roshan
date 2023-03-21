using CollegeManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Web.data
{
    public class CollegeDbContext: DbContext
    {
        public DbSet<Student> students { get; set; }
        public object Students { get; internal set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=CollegeDb;Integrated Security=True;");
        }
    }
}
