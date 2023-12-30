using Microsoft.AspNetCore.Mvc;

namespace SMS.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login(string ReturnUrl) 
        {
            ViewData["returnedURL"] = ReturnUrl;
            return View();
        }
    }
}
