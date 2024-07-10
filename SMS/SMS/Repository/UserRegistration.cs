using IdentityAPP.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SMS.DBContext;
using SMS.Helper;
using SMS.IRepository;
using SMS.Models;
using SMS.Services.UploadFile.Interface;
using SMS.ViewModel.AdmitCardPrint;
using SMS.ViewModel.ApplicantInfo;
using System.ComponentModel.DataAnnotations;

namespace SMS.Repository
{
    public class UserRegistration : IUserRegistration
    {
        private readonly AppDbContext _context;
        private readonly LoggedInUserInfo _loggedInUser;
        private readonly SmtpService _smtpService;
        private readonly CodeGenerator _codeGenerator;
        private readonly IUploadfile  _uploadFile;

        public UserRegistration(AppDbContext context, LoggedInUserInfo loggedInUser, SmtpService smtpService, CodeGenerator codeGenerator, IUploadfile uploadFile)
        {
            _context = context;
            _loggedInUser = loggedInUser;
            _smtpService = smtpService;
            _codeGenerator = codeGenerator;
            _uploadFile = uploadFile;
        }

        public async Task<MessageHelper> CreateApplicant(ApplicantViewModel model, IFormFile file)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var Head = model.HeaderModel;
                    var Academic = model.AcademicModel;
                    List<TblApplicantAcademicInfo> AddList = new List<TblApplicantAcademicInfo>();
                    var Attachment = await _uploadFile.FileUpload(file);
                    var DupEmail = await _context.TblApplicantInfoHeader.Where(x => x.StrEmail == Head.Email && x.IsActive == true).FirstOrDefaultAsync();
                    if (DupEmail != null)
                    {
                        throw new Exception("This email is already used.");
                    }

                    string code = "";
                    code = await _codeGenerator.GetApplicantAddmissionCode(Head.SemesterId);

                    TblApplicantInfoHeader head = new TblApplicantInfoHeader()
                    {
                        StrRegistrationCode = code,
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
                        StrAttachment = Attachment,
                        NumTotalMark = 0,
                        IsPassed = false,
                        IsForPostGraduate = false,
                        IsActive = true,
                        IsClose = false,
                        IsApprove = false,
                        FatherName = Head.FatherName,
                        MotherName = Head.MotherName,
                        
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
                        IsActive = true,
                        StrGroup = x.Group
                    }).ToList();

                    await _context.TblApplicantAcademicInfo.AddRangeAsync(AddList);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return new MessageHelper
                    {
                        Message = "Created Successfully",
                        StatusCode = 200,
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new MessageHelper
                    {
                        Message = ex.Message,
                        StatusCode = 500
                    };
                }
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
                                          where (appInfo.IntFirstDepartmentId == departmentId || departmentId == 0 || departmentId == null)
                                          && appInfo.IsActive == true && dept.IsActive == true && sem.IsActive == true && sem.IsRunning == true
                                          select new GetApplicantHeaderInfoViewModel
                                          {
                                              Id=appInfo.IntId,
                                              SemesterName = sem.StrSemesterName,
                                              FullName = appInfo.StrFullName,
                                              FirstDepartmentName = dept.StrDepartmentName,
                                              OptionalDepartmentName = dept2.StrDepartmentName,
                                              Email = appInfo.StrEmail,
                                              ContactNumber = appInfo.StrContactNumber,
                                              Address = appInfo.StrAddress,
                                              Gender = appInfo.StrGender,
                                              Nationality = appInfo.StrNationality,
                                              DoB = appInfo.DteDoB.Date,
                                              RegistrationCode = appInfo.StrRegistrationCode,
                                              Religion = appInfo.StrReligion,
                                              IsApprove = appInfo.IsApprove,
                                              IsClose = appInfo.IsClose,
                                              IsActive = appInfo.IsActive,
                                              AcademicInfo = (from ac in _context.TblApplicantAcademicInfo
                                                              where ac.IntApplicantHeaderId == appInfo.IntId
                                                              && ac.IsActive == true
                                                              select new GetApplicantAcademicInfoViewModel
                                                              {
                                                                  InstitutionName = ac.StrInstitutionName,
                                                                  RegistrationNumber = ac.StrRegistrationNumber,
                                                                  Board = ac.StrBoard,
                                                                  Result = ac.NumResult,
                                                                  Scale = ac.StrScale,
                                                                  PassingYear = ac.IntPassingYear,
                                                                  Group = ac.StrGroup
                                                              }).ToList()
                                          }).ToListAsync();

                return PersonalData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageHelper> ApproveApplicant(long Id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var loggedInUser = _loggedInUser.GetLoggedInUserInfo();
                    var ApplicantData = await _context.TblApplicantInfoHeader
                                                      .Where(x => x.IntId == Id && x.IsActive == true && x.IsApprove == false && x.IsClose == false)
                                                      .FirstOrDefaultAsync();

                    if (ApplicantData == null)
                    {
                        throw new Exception("Applicant Not Found.");
                    }

                   DateTime? AddmissionDate = await _context.TblSemester
                                                   .Where(x => x.IntId == ApplicantData.IntSemesterId && x.IsActive == true)
                                                   .Select(x => x.DteAdmissionDate)
                                                   .FirstOrDefaultAsync();
                    if (AddmissionDate == null)
                    {
                        throw new Exception("Please set Addmission ExamDate.");
                    }

                    string Password = $"{ApplicantData.StrFirstName}@123";
                    ApplicantData.DteApproveDate = DateTime.Now;
                    ApplicantData.IsApprove = true;
                    ApplicantData.IntApproveBy = Convert.ToInt64(loggedInUser.UserId);
                    _context.TblApplicantInfoHeader.Update(ApplicantData);
                    await _context.SaveChangesAsync();

                    var User = new TblUser
                    {
                        StrFirstName = ApplicantData.StrFirstName,
                        StrLastName = ApplicantData.StrLastName,
                        StrFullName = ApplicantData.StrFullName,
                        StrEmail = ApplicantData.StrEmail,
                        StrPassword = Password,
                        StrContact = ApplicantData.StrContactNumber,
                        IsActive = true,
                        DteLastActionDateTime = DateTime.Now,
                        IntActionBy = Convert.ToInt64(loggedInUser.UserId),
                        IntUserReferenceId = ApplicantData.IntId,
                    };
                    await _context.TblUser.AddAsync(User);
                    await _context.SaveChangesAsync();



                    var role = await _context.TblRole
                                             .Where(x => x.StrRoleName.ToLower().Contains("Applicant".ToLower()) && x.IsActive == true)
                                             .FirstOrDefaultAsync();

                    if (role == null)
                    {
                        throw new Exception("Role for Applicant Not Found.");
                    }

                    var UserRole = new TblUserRole
                    {
                        IntUserId = User.IntId,
                        IntRoleId = role.IntId,
                        IsActive = true
                    };
                    await _context.TblUserRole.AddAsync(UserRole);
                    await _context.SaveChangesAsync();

                    string DateString = AddmissionDate?.ToString("ddd dd MMM yyyy hh:mm tt") ?? "";
                    var EBody = EmailBody.ApplicantApprovalBody(ApplicantData.StrFullName, ApplicantData.StrRegistrationCode, User.StrEmail, User.StrPassword, loggedInUser.UserName ?? "", DateString);
                    var ESubject = "Applicant's Registration";
                    await _smtpService.SendEmailAsync(User.StrFullName, User.StrEmail, ESubject, EBody);

                    await transaction.CommitAsync();
                    return new MessageHelper
                    {
                        Message = "Approved Successfully",
                        StatusCode = 200
                    };
                }

                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Failed to Approve.");
                }
            }
        }

        //public async Task<MessageHelper> RejectApplicant(long Id)
        //{
        //    try
        //    {
        //        //var userInfo = _contextAccessor.HttpContext.User;
        //        var UserId = userInfo.FindAll(System.Security.Claims.ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault();

        //        var Data = await _context.TblApplicantInfoHeader
        //                                 .Where(x => x.IntId == Id
        //                                          && x.IsActive == true
        //                                          && x.IsApprove == false
        //                                          && x.IsClose == false)
        //                                 .FirstOrDefaultAsync();

        //        if (Data != null)
        //        {
        //            Data.IsClose = true;
        //            Data.IntCloseBy = Convert.ToInt64(UserId);
        //            Data.DteCloseDate = DateTime.Now;
        //        }

        //        return new MessageHelper
        //        {
        //            Message = "Rejected Successfully",
        //            StatusCode = 200
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<GetApplicantHeaderPrintViewModel> GetApplicantAdmitCard()
        {
            try
            {
                var LoggedInUserId = _loggedInUser.GetLoggedInUserInfo().UserId;
                var UserReferenceId = await _context.TblUser.Where(x => x.IntId == Convert.ToInt64(LoggedInUserId ?? "0") && x.IsActive == true).Select(x => x.IntUserReferenceId).FirstOrDefaultAsync() ?? 0;

                var PersonalData = await (from appInfo in _context.TblApplicantInfoHeader
                                          join dept in _context.TblDepartment on appInfo.IntFirstDepartmentId equals dept.IntId
                                          join dept2 in _context.TblDepartment on appInfo.IntOptionalDepartmentId equals dept2.IntId
                                          join sem in _context.TblSemester on appInfo.IntSemesterId equals sem.IntId
                                          where appInfo.IntId == UserReferenceId
                                          && appInfo.IsActive == true && dept.IsActive == true && sem.IsActive == true && sem.IsRunning == true
                                          select new GetApplicantHeaderPrintViewModel
                                          {
                                              SemesterName = sem.StrSemesterName,
                                              FullName = appInfo.StrFullName,
                                              FirstDepartmentName = dept.StrDepartmentName,
                                              OptionalDepartmentName = dept2.StrDepartmentName,
                                              Email = appInfo.StrEmail,
                                              ContactNumber = appInfo.StrContactNumber,
                                              Address = appInfo.StrAddress,
                                              Gender = appInfo.StrGender,
                                              Nationality = appInfo.StrNationality,
                                              DoB = appInfo.DteDoB.Date,
                                              RegistrationCode = appInfo.StrRegistrationCode,
                                              Religion = appInfo.StrReligion,
                                              FatherName = appInfo.FatherName,
                                              MotherName =  appInfo.MotherName,
                                              ExamDateTime = sem.DteAdmissionDate,
                                              Attachment = appInfo.StrAttachment,
                                              AcademicInfo = (from ac in _context.TblApplicantAcademicInfo
                                                              where ac.IntApplicantHeaderId == appInfo.IntId
                                                              && ac.IsActive == true
                                                              select new GetApplicantAcademicPrintViewModel
                                                              {
                                                                  InstitutionName = ac.StrInstitutionName,
                                                                  RegistrationNumber = ac.StrRegistrationNumber,
                                                                  Board = ac.StrBoard,
                                                                  Result = ac.NumResult,
                                                                  Scale = ac.StrScale,
                                                                  PassingYear = ac.IntPassingYear,
                                                                  Group = ac.StrGroup
                                                              }).ToList()
                                          }).FirstOrDefaultAsync();

                return PersonalData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         

    }
}
