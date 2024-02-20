using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModel.ApplicantInfo
{
 
    public class GetApplicantHeaderInfoViewModel
    {
        public long Id { get; set; }
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
        public List<GetApplicantAcademicInfoViewModel> AcademicInfo { get; set; }

    }
    public class GetApplicantAcademicInfoViewModel
    {
        public long Id { get; set; }
        public long ApplicantHeaderId { get; set; }
        public string InstitutionName { get; set; }
        public string? Board { get; set; }
        public string? RegistrationNumber { get; set; }
        public long PassingYear { get; set; }
        public decimal Result { get; set; }
        public string? Scale { get; set; }
    }
}
