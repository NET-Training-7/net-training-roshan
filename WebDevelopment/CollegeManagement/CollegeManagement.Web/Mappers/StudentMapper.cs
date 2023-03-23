using CollegeManagement.Web.Models;
using CollegeManagement.Web.ViewModels;

namespace CollegeManagement.Web.Mappers;

public static class StudentMapper
{
    public static Student ToModel(this StudentViewModel studentVM) =>
     new Student
     {
         Name = studentVM.Name,
         Dob = studentVM.Dob,
         Contact = studentVM.Contact,
         Address = studentVM.Address,
         Gender = studentVM.Gender,
         Email = studentVM.Email,
         Major = studentVM.Major,
         Program = studentVM.Program,
         RollNo = studentVM.RollNo,
         Semester = studentVM.Semester

     };
    public static StudentViewModel ToViewModel(this Student student) =>
     new StudentViewModel
     {
         Name = student.Name,
         Dob = student.Dob,
         Contact = student.Contact,
         Address = student.Address,
         Gender = student.Gender,
         Email = student.Email,
         Major = student.Major,
         Program = student.Program,
         RollNo = student.RollNo,
         Semester = student.Semester,
         AvatarPath = student.AvatarPath
     };
    public static List<StudentViewModel> ToViewModel(this List<Student> students) =>
  students.Select(student => ToViewModel(student)).ToList();


}
