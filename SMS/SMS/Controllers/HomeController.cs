using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.DBContext;
using SMS.Models;
using System.Diagnostics;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor, AppDbContext context)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public IActionResult Index()
        {
            var userInfo = _contextAccessor.HttpContext.User;
            if (userInfo.Identity.IsAuthenticated == true)
            {
                if (userInfo.IsInRole("SuperAdmin"))
                {
                    return RedirectToAction("SuperAdmin", "Home");
                }

                else if (userInfo.IsInRole("Student"))
                {
                    return RedirectToAction("Student", "Home");
                }

                else
                {
                    return RedirectToAction("Applicant", "Home");
                }
                
            }
            return View();
        }


        [Authorize(Policy = "SuperAdminPolicy")]
        public IActionResult SuperAdmin()
        {
            return View();
        }


        [Authorize(Policy = "ApplicantPolicy")]
        public  IActionResult Applicant()
        {
            DateTime CD = DateTime.Now;
            var Sem = (from s in _context.TblSemester
                               where s.IsRunning == true
                               && CD <= s.DteApplicationDeadLine
                               && s.IsActive == true
                               select new
                               {
                                   IsRunning = s.IsRunning,
                               }).FirstOrDefault();
            //ViewBag.IsSemesterRunning = Sem.IsRunning;
            ViewBag.IsSemesterRunning = true;
            return View();
        }

        [Authorize(Policy = "StudentPolicy")]
        public IActionResult Student()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}