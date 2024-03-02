using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblCodeGenerator
    {
        [Key]
        public long IntId { get; set; }
        public string StrType { get; set; }
        public long IntSemesterId { get; set; }
        public long IntDepartmentId { get; set; }
        public long IntSerialCount { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
    }
}
