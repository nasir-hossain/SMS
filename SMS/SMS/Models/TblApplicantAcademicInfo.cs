using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblApplicantAcademicInfo
    {
        [Key]
        public long IntId { get; set; }
        public long IntApplicantHeaderId { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 500 characters.")]
        public string StrInstitutionName { get; set; }
        public string? StrBoard { get; set; }
        public string? StrRegistrationNumber { get; set; }
        public long IntPassingYear { get; set; }
        public decimal NumResult { get; set; }
        public string? StrScale { get; set; }
        public bool? IsActive { get; set; }
    }
}
