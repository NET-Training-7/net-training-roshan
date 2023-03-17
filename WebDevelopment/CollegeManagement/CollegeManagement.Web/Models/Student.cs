using CollegeManagement.Web.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Web.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int RollNo { get; set; }
        [Required(ErrorMessage = "We need your name")]
        [MinLength(2, ErrorMessage = "At least 2 letter please")]
        [RegularExpression("[A-Za-z ]+", ErrorMessage = "Only alphabets and space are allowed.")]
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public Sex Gender { get; set; }
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? Dob { get; set; }

        public string Contact { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Major { get; set; } = string.Empty;

        public string Semester { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? Avatar { get; set; }
        public string? AvatarPath { get; set; }
    }
}
