using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.IRepository;
using SMS.Repository;
using SMS.ViewModel;

namespace SMS.Controllers
{
    [Authorize(Policy = "SuperAdminPolicy")]
    public class MasterServiceController : Controller
    {
        private readonly IMasterService _IRepository;
        public MasterServiceController(IMasterService IRepository)
        {
             _IRepository = IRepository;
        }

        [HttpGet]
        public IActionResult CreateSemester()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSemester(SemesterViewModel model)
        {
            var msg = await _IRepository.CreateSemester(model);
            ViewBag.msg = msg.Message;
            // return View(model);
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetSemester()
        {
            var Data = await _IRepository.GetSemester();
            return View(Data);
        } 
        

        [HttpGet]
        public IActionResult DeleteSemester()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> DeleteSemester(long Id)
        {
            var msg = await _IRepository.DeleteSemester(Id);
            return View();
        }
    }
}
