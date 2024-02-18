using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.DBContext;
using SMS.IRepository;
using SMS.ViewModel;
using SMS.ViewModel.ApplicantInfo;

namespace SMS.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly IUserRegistration _IRepository;
        private readonly IMasterService _masterService;
        private readonly AppDbContext _context;

        public UserRegistrationController(IUserRegistration IRepository, AppDbContext context, IMasterService masterService)
        {
            _IRepository = IRepository;
            _context = context;
            _masterService = masterService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateApplicant()
        {
            List<DepartmentViewModel> departmentList = new List<DepartmentViewModel>();
            List<SemesterViewModel> SemesterList = new List<SemesterViewModel>();
            ApplicantViewModel ViewModel = new ApplicantViewModel();
            ViewModel.SemesterModel = new List<SelectListItem>();

            departmentList = await _masterService.GetDepartment();
            SemesterList = await _masterService.GetSemester();

            //departmentList.ForEach(x =>
            //{
            //    SelectListItem DDLData = new SelectListItem()
            //    {
            //        Text = x.DepartmentName,
            //        Value = x.Id.ToString(),
            //    };

            //    model.DepartmentModel.Add(DDLData);
            //});


            SemesterList.ForEach(x =>
            {
                SelectListItem DDLData = new SelectListItem()
                {
                    Text = x.SemesterName,
                    Value = x.Id.ToString(),
                };

                ViewModel.SemesterModel.Add(DDLData);
            });


            return View(ViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> CreateApplicant(ApplicantViewModel model)
        {

            List<DepartmentViewModel> departmentList = new List<DepartmentViewModel>();
            List<SemesterViewModel> SemesterList = new List<SemesterViewModel>();
            ApplicantViewModel ViewModel = new ApplicantViewModel();
            ViewModel.SemesterModel = new List<SelectListItem>();

            departmentList = await _masterService.GetDepartment();
            SemesterList = await _masterService.GetSemester();

            //departmentList.ForEach(x =>
            //{
            //    SelectListItem DDLData = new SelectListItem()
            //    {
            //        Text = x.DepartmentName,
            //        Value = x.Id.ToString(),
            //    };

            //    model.DepartmentModel.Add(DDLData);
            //});


            SemesterList.ForEach(x =>
            {
                SelectListItem DDLData = new SelectListItem()
                {
                    Text = x.SemesterName,
                    Value = x.Id.ToString(),
                };

                ViewModel.SemesterModel.Add(DDLData);
            });


            await _IRepository.CreateApplicant(model);
            return View(ViewModel);
        }
    }
}
