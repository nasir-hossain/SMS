using Microsoft.AspNetCore.Mvc.Rendering;

namespace SMS.ViewModel.ApplicantInfo
{
    public class ApplicantViewModel
    {
        public List<ApplicantAcademicInfoViewModel> AcademicModel { get; set; }
        public ApplicantInfoHeaderViewModel HeaderModel { get; set; }

        public List<SelectListItem>SemesterModel { get; set; }
        public List<SelectListItem> DepartmentModel { get; set; }
    }
}
