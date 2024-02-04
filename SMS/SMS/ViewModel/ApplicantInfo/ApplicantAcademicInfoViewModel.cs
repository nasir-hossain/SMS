using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModel.ApplicantInfo
{
    public class ApplicantAcademicInfoViewModel
    {
        public long Id { get; set; }
        public long ApplicantHeaderId { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 500 characters.")]
        public string InstitutionName { get; set; }
        public string? Board { get; set; }
        public string? RegistrationNumber { get; set; }
        public long PassingYear { get; set; }
        public decimal Result { get; set; }
        public string? Scale { get; set; }
    }
}
