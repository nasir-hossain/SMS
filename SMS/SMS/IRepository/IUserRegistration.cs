using SMS.Helper;
using SMS.ViewModel.ApplicantInfo;

namespace SMS.IRepository
{
    public interface IUserRegistration
    {
        public Task<MessageHelper> CreateApplicant(ApplicantViewModel model);
    }
}
