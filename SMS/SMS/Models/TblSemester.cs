using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblSemester
    {
        [Key]
        public long IntId { get; set; }
        public string  StrSemesterName{ get; set; }
        public bool  IsActive{ get; set; }
    }
}
