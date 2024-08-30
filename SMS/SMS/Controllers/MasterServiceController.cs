using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SMS.DBContext;
using SMS.IRepository;
using SMS.Models;
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

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] List<GetCourseViewModelToAdd> obj)
        {
            try
            {
                var AddList = obj.Select(x => new TblCourse
                {
                    StrCourseName = x.CourseName,
                    StrCourseCode = x.CourseCode,
                    IntDepartmentId = x.DepartmentId,
                    NumCredit = x.Credit,
                    IsActive = true

                }).ToList();

                await _context.TblCourse.AddRangeAsync(AddList);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Created Successfully",
                    StatusCode = 200,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCourseToAdd([FromBody] GetCourseViewModelToAdd newObj)
        {
            try
            {
                List<GetCourseViewModelToAdd> objList = new List<GetCourseViewModelToAdd>();

                var data = new GetCourseViewModelToAdd
                {
                    DepartmentId = newObj.DepartmentId,
                    DepartmentName = await _context.TblDepartment.Where(x => x.IntId == newObj.DepartmentId).Select(x => x.StrDepartmentName).FirstOrDefaultAsync() ?? "",
                    CourseName = newObj.CourseName,
                    CourseCode = newObj.CourseCode,
                    Credit = newObj.Credit
                };

                // Retrieve existing session data
                string? getSessionData = HttpContext.Session.GetString("JsonObjList");

                if (!string.IsNullOrEmpty(getSessionData))
                {
                    var sessionList = JsonConvert.DeserializeObject<List<GetCourseViewModelToAdd>>(getSessionData);
                    if (sessionList != null)
                    {
                        objList.AddRange(sessionList);
                    }
                }

                objList.Add(data);

                // Update the session with the new data
                HttpContext.Session.SetString("JsonObjList", JsonConvert.SerializeObject(objList));

                return Ok(objList);  // Jehetu Js diye Call Korechi tai Json Return korechi.
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetCourse(long? departmentId)
        {

            List<SelectListItem> SelectedList = new List<SelectListItem>();
            var DepartmentList = await _masterService.GetDepartment();

            DepartmentList.ForEach(x =>
            {
                var selectedItem = new SelectListItem()
                {
                    Text = x.DepartmentName,
                    Value = x.Id.ToString(),
                };

                SelectedList.Add(selectedItem);
            });

            var Data = await _IRepository.GetCourse(departmentId);
            ViewBag.DeptDDL = SelectedList;
            HttpContext.Session.Clear();
            return View(Data);
        }



        [HttpGet]
        public IActionResult GetSessionData()
        {
            List<GetCourseViewModelToAdd> objList = new List<GetCourseViewModelToAdd>();

            string? getSessionData = HttpContext.Session.GetString("JsonObjList");
            if (!string.IsNullOrEmpty(getSessionData))
            {
                var sessionList = JsonConvert.DeserializeObject<List<GetCourseViewModelToAdd>>(getSessionData);
                if (sessionList != null)
                {
                    objList.AddRange(sessionList);
                }
            }

            return Ok(objList);
        }

        [HttpGet]
        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return Ok("Session Cleared");
        }

        #endregion
    }

}
