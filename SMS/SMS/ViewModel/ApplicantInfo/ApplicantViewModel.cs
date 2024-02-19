using Microsoft.AspNetCore.Mvc.Rendering;

namespace SMS.ViewModel.ApplicantInfo
{
    public class ApplicantViewModel
    {
        public List<ApplicantAcademicInfoViewModel> AcademicModel { get; set; }
        public ApplicantInfoHeaderViewModel HeaderModel { get; set; }

        public List<SelectListItem>SemesterModel { get; set; }
        public List<SelectListItem> DepartmentModel { get; set; }
        public List<SelectListItem> Nationality { get; set; }
        public List<SelectListItem> Religion { get; set; }
        public List<SelectListItem> School { get; set; }
        public List<SelectListItem> College { get; set; }
        public List<SelectListItem> Board { get; set; }
        public List<SelectListItem> Year { get; set; }
    }
}
