using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModel.CourseInfo
{
    public class GetCourseViewModel
    {
        public long Id { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public decimal Credit { get; set; }
    }
}
