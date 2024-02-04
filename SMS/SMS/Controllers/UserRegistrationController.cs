using Microsoft.AspNetCore.Mvc;
using SMS.DBContext;
using SMS.IRepository;
using SMS.ViewModel.ApplicantInfo;

namespace SMS.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly IUserRegistration _IRepository;
        private readonly AppDbContext _context;

        public UserRegistrationController(IUserRegistration IRepository, AppDbContext context)
        {
            _IRepository= IRepository;
            _context= context;
        }

        [HttpGet]
        public async Task<IActionResult> CreateApplicant()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateApplicant(ApplicantViewModel model)
        {
            await _IRepository.CreateApplicant(model);
            return View();
        }
    }
}
