using SMS.Helper;
using SMS.ViewModel;

namespace SMS.IRepository
{
    public interface IMasterService
    {
        public Task<MessageHelper> CreateSemester(SemesterViewModel model);
        public Task<List<SemesterViewModel>> GetSemester();
        public Task<MessageHelper> DeleteSemester(long Id);


        public Task<MessageHelper> CreateDepartment(DepartmentViewModel model);
        public Task<List<DepartmentViewModel>> GetDepartment();
        public Task<MessageHelper> DeleteDepartment(long Id);


    }
}
