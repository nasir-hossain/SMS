using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModel.ApplicantInfo
{
    public class ApplicantInfoHeaderViewModel
    {
        public long Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string RegistrationCode { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string FullName { get; set; }

        [Required]
        public DateTime DoB { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string Gender { get; set; }

        [Required]
        public long FirstDepartmentId { get; set; }
        public long OptionalDepartmentId { get; set; }

        [Required]
        public long SemesterId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string Email { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]

        public string Address { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string Nationality { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 150 characters.")]
        public string Religion { get; set; }

        public string? Attachment { get; set; } = string.Empty;
    }
}
