using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblApplicantInfoHeader
    {
        [Key]
        public long IntId { get; set; }
        [Required]
        [StringLength(150, MinimumLength =1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string StrRegistrationCode { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string StrFirstName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string StrLastName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string StrFullName { get; set; }

        [Required]
        public DateTime DteDoB { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string StrGender  { get; set; }

        [Required]
        public long IntFirstDepartmentId { get; set; }
        public long IntOptionalDepartmentId { get; set; }

        [Required]
        public long IntSemesterId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string StrEmail { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string StrContactNumber { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]

        public string StrAddress { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string StrNationality { get; set; }
        
        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string StrReligion { get; set; }

        public DateTime? DteActionDateTime { get; set; }

        public string? StrAttachment { get; set; } = string.Empty;
        public decimal? NumTotalMark { get; set; } = 0;  
        public bool? IsPassed { get; set; }   = false;
        public bool? IsForPostGraduate { get; set; } = false;
        public bool? IsActive { get; set; } = false;
        public bool? IsClose { get; set; } = false;
        public bool? IsApprove { get; set; } = false;

    }
}
