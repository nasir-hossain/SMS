﻿using SMS.Helper;
using SMS.ViewModel.ApplicantInfo;

namespace SMS.IRepository
{
    public interface IUserRegistration
    {
        public Task<MessageHelper> CreateApplicant(ApplicantViewModel model);
        public Task<List<GetApplicantHeaderInfoViewModel>> GetApplicantInfo(long? departmentId);
        public Task<MessageHelper> ApproveApplicant(long Id);
       // public Task<GetApplicantHeaderInfoViewModel> GetLoggedInApplicantData();
        
    }
}
