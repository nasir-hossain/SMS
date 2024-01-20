using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblDepartment
    {
        
        [Key]
        public long IntId { get; set; }
        public string  StrDepartmentName{ get; set; }
        public bool IsActive { get; set; }
    }
}
