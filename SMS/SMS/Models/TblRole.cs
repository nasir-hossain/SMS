using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblRole
    {
        [Key]
        public long IntId { get; set; }
        public string StrRoleName { get; set; } = "";
        public bool IsActive { get; set; }
    }
}
