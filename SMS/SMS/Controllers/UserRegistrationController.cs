using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.DBContext;
using SMS.Helper;
using SMS.IRepository;
using SMS.Services.UploadFile.Interface;
using SMS.ViewModel;
using SMS.ViewModel.ApplicantInfo;

namespace SMS.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly IUserRegistration _IRepository;
        private readonly IMasterService _masterService;
        private readonly IUploadfile _uploadFile;
        private readonly AppDbContext _context;

        public UserRegistrationController(IUserRegistration IRepository, AppDbContext context, IMasterService masterService, IUploadfile uploadFile)
        {
            _IRepository = IRepository;
            _context = context;
            _masterService = masterService;
            _uploadFile = uploadFile;
        }

        [HttpGet]
        public async Task<IActionResult> CreateApplicant()
        {
            try
            {
                ApplicantViewModel ViewModel = new ApplicantViewModel();
                ViewModel.DepartmentModel = new List<SelectListItem>();
                ViewModel.SemesterModel = new List<SelectListItem>();
                ViewModel.Nationality = new List<SelectListItem>();
                ViewModel.Religion = new List<SelectListItem>();
                ViewModel.School = new List<SelectListItem>();
                ViewModel.College = new List<SelectListItem>();
                ViewModel.Board = new List<SelectListItem>();
                ViewModel.Year = new List<SelectListItem>();

                var departmentList = await _masterService.GetDepartment();
                var SemesterList = await _masterService.GetSemester();
                var Nationality = DDLService.GetNationality();
                var Religion = DDLService.GetReligion();
                var School = DDLService.GetSchool();
                var College = DDLService.GetCollege();
                var Board = DDLService.GetEducationBoard();
                var Year = DDLService.GetYear();


                departmentList.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.DepartmentName,
                        Value = x.Id.ToString(),
                    };

                    ViewModel.DepartmentModel.Add(DDLData);
                });


                SemesterList.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.SemesterName,
                        Value = x.Id.ToString(),
                    };

                    ViewModel.SemesterModel.Add(DDLData);
                });


                Nationality.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        // Value = x.Id.ToString(),
                    };
                    ViewModel.Nationality.Add(DDLData);
                });

                Religion.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        // Value = x.Id.ToString(),
                    };
                    ViewModel.Religion.Add(DDLData);
                });

                School.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        // Value = x.Id.ToString(),
                    };
                    ViewModel.School.Add(DDLData);
                });

                College.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        // Value = x.Id.ToString(),
                    };
                    ViewModel.College.Add(DDLData);
                });


                Board.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        //  Value = x.Id.ToString(),
                    };
                    ViewModel.Board.Add(DDLData);
                });


                Year.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        // Value = x.Id.ToString(),
                    };
                    ViewModel.Year.Add(DDLData);
                });

                //Passing Data from Controller To View By Model Object
                return View(ViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

          

        }


        [HttpPost]
        public async Task<IActionResult> CreateApplicant(ApplicantViewModel model, IFormFile file)
        {
            try
            {
                // Jehetu Post Method a View Return korechi tai DDL er Jonno Data Pathate hobe .. Ta na hole Null Exception Dibe.


                ApplicantViewModel ViewModel = new ApplicantViewModel();
                ViewModel.DepartmentModel = new List<SelectListItem>();
                ViewModel.SemesterModel = new List<SelectListItem>();
                ViewModel.Nationality = new List<SelectListItem>();
                ViewModel.Religion = new List<SelectListItem>();
                ViewModel.School = new List<SelectListItem>();
                ViewModel.College = new List<SelectListItem>();
                ViewModel.Board = new List<SelectListItem>();
                ViewModel.Year = new List<SelectListItem>();

                var departmentList = await _masterService.GetDepartment();
                var SemesterList = await _masterService.GetSemester();
                var Nationality = DDLService.GetNationality();
                var Religion = DDLService.GetReligion();
                var School = DDLService.GetSchool();
                var College = DDLService.GetCollege();
                var Board = DDLService.GetEducationBoard();
                var Year = DDLService.GetYear();


                departmentList.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.DepartmentName,
                        Value = x.Id.ToString(),
                    };

                    ViewModel.DepartmentModel.Add(DDLData);
                });


                SemesterList.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.SemesterName,
                        Value = x.Id.ToString(),
                    };

                    ViewModel.SemesterModel.Add(DDLData);
                });


                Nationality.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        //Value = x.Id.ToString(),
                    };
                    ViewModel.Nationality.Add(DDLData);
                });

                Religion.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        // Value = x.Id.ToString(),
                    };
                    ViewModel.Religion.Add(DDLData);
                });

                School.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        // Value = x.Id.ToString(),
                    };
                    ViewModel.School.Add(DDLData);
                });

                College.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        // Value = x.Id.ToString(),
                    };
                    ViewModel.College.Add(DDLData);
                });


                Board.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        //  Value = x.Id.ToString(),
                    };
                    ViewModel.Board.Add(DDLData);
                });


                Year.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.Name,
                        // Value = x.Id.ToString(),
                    };
                    ViewModel.Year.Add(DDLData);
                });


                await _IRepository.CreateApplicant(model, file);
                return View(ViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetApplicantInfo(long? departmentId)
        {
            try
            {
                var SelectedList = new List<SelectListItem>();
                var departmentList = await _masterService.GetDepartment();

                departmentList.ForEach(x =>
                {
                    SelectListItem DDLData = new SelectListItem()
                    {
                        Text = x.DepartmentName,
                        Value = x.Id.ToString(),
                    };

                    SelectedList.Add(DDLData);
                });

                ViewBag.SelectedList = SelectedList;
                //return View(new GetApplicantInfoViewModel());
                var data = await _IRepository.GetApplicantInfo(departmentId);
                return View(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public async Task<IActionResult> ApproveApplicant(long Id)
        {
            try
            {
                var data = await _IRepository.ApproveApplicant(Id);
                return RedirectToAction("GetApplicantInfo", "UserRegistration");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public IActionResult TestFileUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestFileUpload(IFormFile file)
        {
            var data = await _uploadFile.FileUpload(file);
            return View();
        }
    }
}
