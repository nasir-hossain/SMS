using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModel.CourseInfo
{
    public class CreateCourseViewModel
    {
        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string CourseName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 50 characters.")]
        public string CourseCode { get; set; }

        [Required]
        public long DepartmentId { get; set; }
        [Required]
        public decimal Credit { get; set; }
    }
}
