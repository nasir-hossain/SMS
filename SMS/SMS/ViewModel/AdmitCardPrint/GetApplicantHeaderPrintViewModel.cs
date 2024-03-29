using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModel.AdmitCardPrint
{
 
    public class GetApplicantHeaderPrintViewModel
    {
        public string RegistrationCode { get; set; }
        public string FullName { get; set; }
        public DateTime DoB { get; set; }
        public string Gender { get; set; }
        public string FirstDepartmentName { get; set; }
        public string OptionalDepartmentName { get; set; }
        public string SemesterName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string? FatherName { get; set; } = null;
        public string? MotherName { get; set; } = null;
        public DateTime? ExamDateTime { get; set; } = null;
        public string? Attachment { get; set; } = null;
        public List<GetApplicantAcademicPrintViewModel> AcademicInfo { get; set; }

    }
    public class GetApplicantAcademicPrintViewModel
    {
        public string InstitutionName { get; set; }
        public string? Board { get; set; }
        public string? RegistrationNumber { get; set; }
        public long PassingYear { get; set; }
        public decimal Result { get; set; }
        public string? Scale { get; set; }
        public string? Group { get; set; }
    }
}
