using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SMS.DBContext;
using SMS.Helper;
using SMS.IRepository;
using SMS.Models;
using SMS.ViewModel.ApplicantInfo;
using System.ComponentModel.DataAnnotations;

namespace SMS.Repository
{
    public class UserRegistration : IUserRegistration
    {
        private readonly AppDbContext _context;
        public UserRegistration(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MessageHelper> CreateApplicant(ApplicantViewModel model)
        {
            try
            {
                var Head = model.HeaderModel;
                var Academic = model.AcademicModel;
                List<TblApplicantAcademicInfo> AddList = new List<TblApplicantAcademicInfo>();

                TblApplicantInfoHeader head = new TblApplicantInfoHeader()
                {
                    StrRegistrationCode = "",
                    StrFirstName = Head.FirstName,
                    StrLastName = Head.LastName,
                    StrFullName = Head.FullName,
                    DteDoB = Head.DoB.Date,
                    StrGender = Head.Gender,
                    IntFirstDepartmentId = Head.FirstDepartmentId,
                    IntOptionalDepartmentId = Head.OptionalDepartmentId,
                    IntSemesterId = Head.SemesterId,
                    StrEmail = Head.Email,
                    StrContactNumber = Head.ContactNumber,
                    StrAddress = Head.Address,
                    StrNationality = Head.Nationality,
                    StrReligion = Head.Religion,
                    DteActionDateTime = DateTime.Now,
                    StrAttachment = "",
                    NumTotalMark = 0,
                    IsPassed = false,
                    IsForPostGraduate = false,
                    IsActive = true,
                    IsClose = false
                };

                await _context.TblApplicantInfoHeader.AddAsync(head);
                await _context.SaveChangesAsync();

                AddList = Academic.Select(x => new TblApplicantAcademicInfo
                {
                    IntApplicantHeaderId = head.IntId,
                    StrInstitutionName = x.InstitutionName,
                    StrBoard = x.Board,
                    StrRegistrationNumber = x.RegistrationNumber,
                    IntPassingYear = x.PassingYear,
                    NumResult = x.Result,
                    StrScale = x.Scale,
                    IsActive = true
                }).ToList();

                await _context.TblApplicantAcademicInfo.AddRangeAsync(AddList);
                await _context.SaveChangesAsync();

                return new MessageHelper
                {
                    Message = "Created Successfully",
                    StatusCode = 200,
                };
            }
            catch (Exception ex)
            {
                return new MessageHelper
                {
                    Message = ex.Message,
                    StatusCode = 500
                };
            }
        }

        public async Task<List<GetApplicantHeaderInfoViewModel>> GetApplicantInfo(long? departmentId)
        {
            try
            {
                var PersonalData = await (from appInfo in _context.TblApplicantInfoHeader
                                          join dept in _context.TblDepartment on appInfo.IntFirstDepartmentId equals dept.IntId
                                          join dept2 in _context.TblDepartment on appInfo.IntOptionalDepartmentId equals dept2.IntId
                                          join sem in _context.TblSemester on appInfo.IntSemesterId equals sem.IntId
                                          where (appInfo.IntFirstDepartmentId == departmentId || departmentId == 0)
                                          && appInfo.IsActive == true && dept.IsActive == true && sem.IsActive == true && appInfo.IsClose == false
                                          select new GetApplicantHeaderInfoViewModel
                                          {
                                              SemesterName = sem.StrSemesterName,
                                              FullName = appInfo.StrFullName,
                                              FirstDepartmentName =dept.StrDepartmentName,
                                              OptionalDepartmentName =dept2.StrDepartmentName,
                                              Email =appInfo.StrEmail,
                                              ContactNumber = appInfo.StrContactNumber,
                                              Address = appInfo.StrAddress,
                                              Gender = appInfo.StrGender,
                                              Nationality = appInfo.StrNationality,
                                              DoB = appInfo.DteDoB.Date,
                                              RegistrationCode = appInfo.StrRegistrationCode,
                                              Religion = appInfo.StrReligion
                                          }).ToListAsync();

                return PersonalData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
