using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System.Diagnostics;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
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
        public IActionResult Applicant()
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