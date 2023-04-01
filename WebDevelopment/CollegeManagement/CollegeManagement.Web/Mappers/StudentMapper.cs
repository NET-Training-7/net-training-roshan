using CollegeManagement.Web.Models;
using CollegeManagement.Web.ViewModels;

namespace CollegeManagement.Web.Mappers;

public static class StudentMapper
{
    public static Student ToModel(this StudentViewModel studentVM) =>
     new Student
     {
         Id = studentVM.Id,
         Name = studentVM.Name,
         Dob = studentVM.Dob,
         Contact = studentVM.Contact,
         Address = studentVM.Address,
         Gender = studentVM.Gender,
         Email = studentVM.Email,
         MajorId = studentVM.MajorId,
         Program = studentVM.Program,
         RollNo = studentVM.RollNo,
         Semester = studentVM.Semester

     };
    public static StudentViewModel ToViewModel(this Student student) =>
     new StudentViewModel
     {
         Id =student.Id,
         Name = student.Name,
         Dob = student.Dob,
         Contact = student.Contact,
         Address = student.Address,
         Gender = student.Gender,
         Email = student.Email,
         MajorName = student.Major?.Name ?? "N/A",
         MajorId = student.Major.Id,
         Program = student.Program,
         RollNo = student.RollNo,
         Semester = student.Semester,
         AvatarPath = student.AvatarPath
     };
    public static List<StudentViewModel> ToViewModel(this List<Student> students) =>
  students.Select(student => ToViewModel(student)).ToList();


}
