using Microsoft.AspNetCore.Mvc.Rendering;

namespace SMS.ViewModel.CourseInfo
{
    public class CourseViewModel
    {
        public CreateCourseViewModel CourseModel { get; set; }
        public List<SelectListItem> DepartmentModel { get; set; }

    }
}
