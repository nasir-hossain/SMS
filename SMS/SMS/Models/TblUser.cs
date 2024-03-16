using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblUser
    {
        [Key]
        public long IntId { get; set; }
        public string StrFirstName { get; set; } = "";
        public string StrLastName { get; set; } = "";
        public string StrFullName { get; set; } = "";
        public string StrEmail { get; set; } = "";
        public string StrPassword { get; set; } = "";
        public string? StrContact { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DteLastActionDateTime { get; set; } 
        public long? IntActionBy { get; set; }
        public long? IntUserReferenceId { get; set; }
    }
}
