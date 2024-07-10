using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblCourse
    {
        [Key]
        public long IntId { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string StrCourseName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 50 characters.")]
        public string StrCourseCode { get; set; }

        [Required]
        public long IntDepartmentId { get; set; }
        [Required]
        public decimal NumCredit { get; set; }
        public decimal? NumCourseFee { get; set; }
        public bool IsActive { get; set; }

    }
}
