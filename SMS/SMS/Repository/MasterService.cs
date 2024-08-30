using Microsoft.EntityFrameworkCore;
using SMS.DBContext;
using SMS.Helper;
using SMS.IRepository;
using SMS.Models;
using SMS.ViewModel;
using SMS.ViewModel.CourseInfo;
using System.Diagnostics.Eventing.Reader;

namespace SMS.Repository
{
    public class MasterService : IMasterService
    {
        private readonly AppDbContext _context;
        public MasterService(AppDbContext context)
        {
            _context = context;
        }

        #region============ Semester ================
        public async Task<MessageHelper> CreateSemester(SemesterViewModel model)
        {
            try
            {
                var duplicate = await _context.TblSemester.Where(x => x.StrSemesterName.Trim().ToLower() == model.SemesterName.Trim().ToLower() && x.IsActive == true).FirstOrDefaultAsync();
                if (duplicate != null)
                {
                    throw new Exception($"Semester: {model.SemesterName} already exists.");
                }
                TblSemester Data = new TblSemester
                {
                    StrSemesterName = model.SemesterName,
                    DteApplicationDeadLine=model.ApplicationDeadline,
                    DteLastActionDateTime = DateTime.Now,
                    IsActive = true,
                    IsRunning = true
                };

                await _context.TblSemester.AddAsync(Data);
                await _context.SaveChangesAsync();

                return new MessageHelper()
                {
                    Message = "Created Successfully.",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                //throw ex;
                return new MessageHelper()
                {
                    Message = ex.Message,
                    StatusCode = 500
                };
            }
        }

        public async Task<List<SemesterViewModel>> GetSemester()
        {
            try
            {
                List<SemesterViewModel> Data;
                Data = await (from sem in _context.TblSemester
                              where sem.IsActive == true
                              select new SemesterViewModel
                              {
                                  Id = sem.IntId,
                                  SemesterName = sem.StrSemesterName,
                                  ApplicationDeadline = sem.DteApplicationDeadLine,
                                  AddmissionDate = sem.DteAdmissionDate,
                                  IsRunning= sem.IsRunning,
                                  
                              }).OrderByDescending(x=>x.Id).ToListAsync();
                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageHelper> DeleteSemester(long Id)
        {
            try
            {
                var DataToDelete = await _context.TblSemester.Where(x=>x.IntId == Id && x.IsActive == true).FirstOrDefaultAsync();
                if (DataToDelete != null)
                {
                    DataToDelete.IsActive = false;
                    _context.TblSemester.Update(DataToDelete);
                    await _context.SaveChangesAsync();
                }

                return new MessageHelper() { Message = "Deleted Successfully", StatusCode = 200 };
            }
            catch (Exception ex)
            {
                //throw ex;
                return new MessageHelper() { Message = ex.Message, StatusCode = 500 };
            }
        }

        #endregion


        #region============ Department ==============

        public async Task<MessageHelper> CreateDepartment(DepartmentViewModel model)
        {
            try
            {
                var duplicate = await _context.TblDepartment.Where(x => x.StrDepartmentName.Trim().ToLower() == model.DepartmentName.Trim().ToLower() && x.IsActive == true).FirstOrDefaultAsync();
                if (duplicate != null)
                {
                    throw new Exception($"Semester: {model.DepartmentName} already exists.");
                }

                TblDepartment Data = new TblDepartment
                {
                    StrDepartmentName = model.DepartmentName ?? "",
                    IsActive = true
                };

                await _context.TblDepartment.AddAsync(Data);
                await _context.SaveChangesAsync();

                return new MessageHelper()
                {
                    Message = "Created Successfully.",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                //throw ex;
                return new MessageHelper()
                {
                    Message = ex.Message,
                    StatusCode = 500
                };
            }
        }

        public async Task<List<DepartmentViewModel>> GetDepartment()
        {
            try
            {
                List<DepartmentViewModel> Data;
                Data = await (from sem in _context.TblDepartment
                              where sem.IsActive == true
                              select new DepartmentViewModel
                              {
                                  Id = sem.IntId,
                                  DepartmentName = sem.StrDepartmentName
                              }).OrderByDescending(x=>x.Id).ToListAsync();
                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageHelper> DeleteDepartment(long Id)
        {
            try
            {
                var DataToDelete = await _context.TblDepartment.Where(x => x.IntId == Id && x.IsActive == true).FirstOrDefaultAsync();
                if (DataToDelete != null)
                {
                    DataToDelete.IsActive = false;
                    _context.TblDepartment.Update(DataToDelete);
                    await _context.SaveChangesAsync();
                }

                return new MessageHelper() { Message = "Deleted Successfully", StatusCode = 200 };
            }
            catch (Exception ex)
            {
                //throw ex;
                return new MessageHelper() { Message = ex.Message, StatusCode = 500 };
            }
        }
        #endregion


        #region============ Course Info ===============

        public async Task<MessageHelper> CreateCourse(List<CreateCourseViewModel> viewModel)
        {
            try
            {
                var DataList = new List<TblCourse>();
                DataList = (from c in viewModel
                            select new TblCourse
                            {
                                StrCourseName = c.CourseName,
                                StrCourseCode = c.CourseCode,
                                IntDepartmentId = c.DepartmentId,
                                NumCredit = c.Credit,
                                IsActive = true,
                            }).ToList();

                if (DataList.Any())
                {
                    await _context.TblCourse.AddRangeAsync(DataList);
                    await _context.SaveChangesAsync();
                }

                return new MessageHelper
                {
                    Message = "Created Successfully",
                    StatusCode = 200,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GetCourseViewModel>>GetCourse(long? departmentId)
        {
            try
            {
                var Data = await (from c in _context.TblCourse
                                  join d in _context.TblDepartment on c.IntDepartmentId equals d.IntId
                                  where (c.IntDepartmentId == departmentId || departmentId == 0 || departmentId == null)
                                  && c.IsActive == true && d.IsActive == true
                                  select new GetCourseViewModel
                                  {
                                      Id = c.IntId,
                                      CourseName = c.StrCourseName,
                                      CourseCode = c.StrCourseCode,
                                      DepartmentId = c.IntDepartmentId,
                                      DepartmentName = d.StrDepartmentName,
                                      Credit = c.NumCredit
                                  }).ToListAsync();
                return Data;
            }
            catch(Exception ex)
            {
                throw ex;
            };
        }
        #endregion

    }
}
