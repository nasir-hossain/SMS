using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class TblApplicantInfoHeader
    {
        [Key]
        [Required]
        public long IntId { get; set; }
        [Required]
        [StringLength(150, MinimumLength =1, ErrorMessage = "The field must be between 3 and 150 characters.")]
        public string StrRegistrationCode { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 3 and 150 characters.")]
        public string StrFirstName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 3 and 150 characters.")]
        public string StrLastName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 3 and 150 characters.")]
        public string StrFullName { get; set; }

        [Required]
        public DateTime DteDoB { get; set; }

        [Required]
        public string StrGender  { get; set; }

        [Required]
        public long IntFirstDepartmentId { get; set; }
        public long IntOptionalDepartmentId { get; set; }

        [Required]
        public long IntSemesterId { get; set; }

        [Required]
        public string StrEmail { get; set; }

        [Required]
        public string StrContactNumber { get; set; }

        [Required]
        public string StrFatherName { get; set; }

        [Required]
        public string StrFatherEmail { get; set; }

        [Required]
        public string StrFatherContact { get; set; }

        [Required]
        public string StrAddress { get; set; }

        [Required]
        public string Nationality { get; set; }


        public DateTime? DteActionDateTime { get; set; }

        public string? StrAttachment { get; set; } = string.Empty;
        public decimal? NumTotakMark { get; set; } = 0;  
        public bool? IsPassed { get; set; }   = false;
        public bool? IsForPostGraduate { get; set; } = false;
        public bool? IsActive { get; set; } = false;

    }
}
