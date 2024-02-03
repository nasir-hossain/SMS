using Microsoft.EntityFrameworkCore;
using SMS.DBContext;
using SMS.Helper;
using SMS.IRepository;
using SMS.Models;
using SMS.ViewModel;
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
                    IsActive = true
                };

                await _context.TblSemester.AddAsync(Data);
                await _context.SaveChangesAsync();

                return new MessageHelper()
                {
                    Message = "Create Successfully.",
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
                                  SemesterName = sem.StrSemesterName
                              }).ToListAsync();
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




    }
}
