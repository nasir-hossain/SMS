using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModel
{
    public class DepartmentViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string? DepartmentName { get; set; } = null;
    }
}
