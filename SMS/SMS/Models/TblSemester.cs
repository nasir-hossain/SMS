using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblSemester
    {
        [Key]
        public long IntId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string  StrSemesterName{ get; set; }
        public bool  IsActive{ get; set; }
        public DateTime?  DteLastActionDateTime{ get; set; }
        public DateTime?  DteApplicationDeadLine{ get; set; }

    }
}
