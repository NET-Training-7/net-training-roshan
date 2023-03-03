
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentPortal.Pages
{
    public class StudentListModel : PageModel
    {
        public List<Student> Students { get; set; }
        public void OnGet()
        {
            Students = new List<Student>
            {
              
            };
        }
    }
        public class Student
    {
        public int Rollno { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Major { get; set; }
        public string Semester { get; set; }
}
}