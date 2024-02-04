using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblDepartment
    {
        
        [Key]
        public long IntId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string  StrDepartmentName{ get; set; }
        public bool IsActive { get; set; }
    }
}
