using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.DBContext;
using SMS.IRepository;
using SMS.Repository;
using SMS.ViewModel;

namespace SMS.Controllers
{
    [Authorize(Policy = "SuperAdminPolicy")]
    public class MasterServiceController : Controller
    {
        private readonly IMasterService _IRepository;
        private readonly AppDbContext _context;
        public MasterServiceController(IMasterService IRepository, AppDbContext context)
        {
             _IRepository = IRepository;
             _context = context;
        }

        [HttpGet]
        public IActionResult CreateSemester()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSemester(SemesterViewModel model)
        {
            var obj = await _IRepository.CreateSemester(model);
            TempData["msg"] = obj.Message;
            return RedirectToAction("GetSemester", "MasterService");
        }


        [HttpGet]
        public async Task<IActionResult> GetSemester()
        {
            var Data = await _IRepository.GetSemester();
            ViewBag.Msg = TempData["msg"];
            return View(Data);
        } 
        

        [HttpGet]
        public async Task<IActionResult> DeleteSemester(long? Id) // asp-route-id er maddhome Id ta pabo
        {
            if(Id == null)
            {
                return NotFound();
            }

            var Data = await _context.TblSemester
                                     .Where(x => x.IntId == Id && x.IsActive == true)
                                     .Select(x => new SemesterViewModel
                                     {
                                         Id = x.IntId,
                                         SemesterName = x.StrSemesterName
                                     })
                                     .FirstOrDefaultAsync();
            if(Data == null)
            {
                return NotFound();
            }

            return View(Data);
        }
        

        [HttpPost]
        public async Task<IActionResult> DeleteSemester(long Id)
        {
            var obj = await _IRepository.DeleteSemester(Id);
            TempData["msg"] = obj.Message;
            return RedirectToAction("GetSemester", "MasterService");
        }
    }
}
