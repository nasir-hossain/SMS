using Microsoft.EntityFrameworkCore;
using SMS.DBContext;
using SMS.Migrations;
using SMS.Models;

namespace SMS.Helper
{
    public class CodeGenerator
    {
        private readonly AppDbContext _context;
        public CodeGenerator(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetStudentRegistrationCode(long semesterId,string semesterName)
        {
            string code = "";
            long Year = 1;
            long SemesterOfYear = 0;
            long BatchCount = await _context.TblSemester.Where(x => x.IntId >= semesterId && x.IsActive == true).CountAsync();
            var CodeInfo = await _context.TblCodeGenerator
                                         .Where(x => x.StrType == "Student"
                                                  && x.IntSemesterId == semesterId
                                                  && x.IntBatchCount == BatchCount)
                                         .FirstOrDefaultAsync();
            if (semesterName.ToLower().Contains("spring".ToLower()))
            {
                SemesterOfYear = 1;
            }
            else
            {
                SemesterOfYear = 2;
            }

            long NextSL = 0;

            if (CodeInfo == null)
            {
                NextSL = NextSL + 1;
                var Data = new TblCodeGenerator
                {
                    IntSemesterId = semesterId,
                    IntBatchCount = BatchCount,
                    IntSerialCount = NextSL,
                    DteLastActionDateTime = DateTime.Now,
                    StrType = "Student"
                };
                await _context.TblCodeGenerator.AddAsync(Data);
                await _context.SaveChangesAsync();
            }
            else
            {
                NextSL = CodeInfo.IntSerialCount + 1;
                CodeInfo.IntSerialCount = NextSL;
                CodeInfo.DteLastActionDateTime = DateTime.Now;
                _context.TblCodeGenerator.Update(CodeInfo);
                await _context.SaveChangesAsync();
            }
            code = $"{Year:D1}{SemesterOfYear:D1}{BatchCount:D2}{NextSL:D4}";

            return code;
        }

        public async Task<string> GetApplicantAddmissionCode(long semesterId)
        {
            string code = "";
            long Year = DateTime.Now.Year;
            long BatchCount = await _context.TblSemester.Where(x => x.IntId >= semesterId && x.IsActive == true).CountAsync();
            var CodeInfo = await _context.TblCodeGenerator
                                         .Where(x => x.StrType == "Applicant"
                                                  && x.IntSemesterId == semesterId)
                                         .FirstOrDefaultAsync();
            Year = Year % 100;
            long NextSL = 0;

            if (CodeInfo == null)
            {
                NextSL = NextSL + 1;
                var Data = new TblCodeGenerator
                {
                    IntSemesterId = semesterId,
                    IntBatchCount = BatchCount,
                    IntSerialCount = NextSL,
                    DteLastActionDateTime = DateTime.Now,
                    StrType = "Applicant"
                };
                await _context.TblCodeGenerator.AddAsync(Data);
                await _context.SaveChangesAsync();
            }
            else
            {
                NextSL = CodeInfo.IntSerialCount + 1;
                CodeInfo.IntSerialCount = NextSL;
                CodeInfo.DteLastActionDateTime = DateTime.Now;
                _context.TblCodeGenerator.Update(CodeInfo);
                await _context.SaveChangesAsync();
            }
            code = $"{Year:D2}{BatchCount:D2}{NextSL:D4}";

            return code;
        }
    }
}
