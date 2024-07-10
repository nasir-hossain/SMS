using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS.DBContext;
using SMS.IRepository;
using SMS.Repository;
using SMS.ViewModel;
using SMS.ViewModel.ApplicantInfo;
using SMS.ViewModel.CourseInfo;

namespace SMS.Controllers
{
    [Authorize(Policy = "SuperAdminPolicy")]
    public class MasterServiceController : Controller
    {
        private readonly IMasterService _IRepository;
        private readonly AppDbContext _context;
        private readonly IMasterService _masterService;

        public MasterServiceController(IMasterService IRepository, AppDbContext context, IMasterService masterService)
        {
            _IRepository = IRepository;
            _context = context;
            _masterService = masterService;
        }


        #region=============== Semester =================

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
            if (Id == null)
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
            if (Data == null)
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

        #endregion



        #region============== Department =================

        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentViewModel model)
        {
            var obj = await _IRepository.CreateDepartment(model);
            TempData["msg"] = obj.Message;
            return RedirectToAction("GetDepartment", "MasterService");
        }


        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            var Data = await _IRepository.GetDepartment();
            ViewBag.Msg = TempData["msg"];
            return View(Data);
        }



        [HttpGet]
        public async Task<IActionResult> DeleteDepartment(long? Id) // asp-route-id er maddhome Id ta pabo
        {
            if (Id == null)
            {
                return NotFound();
            }

            var Data = await _context.TblDepartment
                                     .Where(x => x.IntId == Id && x.IsActive == true)
                                     .Select(x => new DepartmentViewModel
                                     {
                                         Id = x.IntId,
                                         DepartmentName = x.StrDepartmentName
                                     })
                                     .FirstOrDefaultAsync();
            if (Data == null)
            {
                return NotFound();
            }

            return View(Data);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteDepartment(long Id)
        {
            var obj = await _IRepository.DeleteDepartment(Id);
            TempData["msg"] = obj.Message;
            return RedirectToAction("GetDepartment", "MasterService");
        }

        #endregion


        #region============== Course Info =================

        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            CourseViewModel ViewModel = new CourseViewModel();
            ViewModel.DepartmentModel = new List<SelectListItem>();
            var departmentList = await _masterService.GetDepartment();
            departmentList.ForEach(x =>
            {
                SelectListItem DDLData = new SelectListItem()
                {
                    Text = x.DepartmentName,
                    Value = x.Id.ToString(),
                };

                ViewModel.DepartmentModel.Add(DDLData);
            });


            return View(ViewModel);
        }



        [HttpGet]
        public async Task<IActionResult> GetCourse(long? departmetId)
        {

            List<SelectListItem> SelectedList = new List<SelectListItem>();
            var DepartmentList =await _masterService.GetDepartment();

            DepartmentList.ForEach(x =>
            {
                var selectedItem = new SelectListItem()
                {
                    Text = x.DepartmentName,
                    Value = x.Id.ToString(),
                };

                SelectedList.Add(selectedItem);
            });

            var Data = await _IRepository.GetCourse(departmetId);
            ViewBag.DeptDDL = SelectedList;
            return View(Data);
        }

        #endregion
    }

}
