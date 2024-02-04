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
                    DteDoB = Head.DoB,
                    StrGender = Head.Gender,
                    IntFirstDepartmentId = Head.FirstDepartmentId,
                    IntOptionalDepartmentId = Head.OptionalDepartmentId,
                    IntSemesterId = Head.SemesterId,
                    StrEmail = Head.Email,
                    StrContactNumber = Head.ContactNumber,
                    StrAddress = Head.Address,
                    StrNationality = Head.Nationality,
                    DteActionDateTime = DateTime.Now,
                    StrAttachment = "",
                    NumTotalMark = 0,
                    IsPassed = false,
                    IsForPostGraduate = false,
                    IsActive = false,
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
    }
}
