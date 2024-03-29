using SMS.Helper;
using SMS.ViewModel.AdmitCardPrint;
using SMS.ViewModel.ApplicantInfo;

namespace SMS.IRepository
{
    public interface IUserRegistration
    {
        public Task<MessageHelper> CreateApplicant(ApplicantViewModel model, IFormFile file);
        public Task<List<GetApplicantHeaderInfoViewModel>> GetApplicantInfo(long? departmentId);
        public Task<MessageHelper> ApproveApplicant(long Id);
        public Task<GetApplicantHeaderPrintViewModel> GetApplicantAdmitCard();
    }
}
