using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblUserRole
    {
        [Key]
        public long IntId { get; set; }
        public long IntUserId { get; set; }
        public long IntRoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
