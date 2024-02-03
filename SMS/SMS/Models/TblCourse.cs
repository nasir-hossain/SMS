using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblCourse
    {
        [Key]
        public long IntId { get; set; }
        public string StrCourseName { get; set; }
        public long IntDepartmentId { get; set; }
        public decimal NumCredit { get; set; }
        public decimal NumCourseFee { get; set; }
        public bool IsActive { get; set; }

    }
}
