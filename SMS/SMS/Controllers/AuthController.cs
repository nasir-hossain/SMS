using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SMS.ViewModel;
using System.Security.Claims;
using SMS.DBContext;
using Microsoft.EntityFrameworkCore;
using SMS.Models;

namespace SMS.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Login(string ReturnUrl) 
        {
            ViewData["returnedURL"] = ReturnUrl;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Verify(LoginViewModel loginObject, string ReturnUrl)
        {

            var UserInfo = await _context.TblUser
                                         .Where(x => x.StrEmail == loginObject.Email 
                                                  && x.StrPassword == loginObject.Password
                                                  && x.IsActive == true)
                                         .FirstOrDefaultAsync();
            if (UserInfo != null)
            {

                List<string> Role = await (from ur in _context.TblUserRole
                                     join r in _context.TblRole on ur.IntRoleId equals r.IntId
                                     where r.IsActive == true && ur.IsActive == true 
                                     && ur.IntUserId == UserInfo.IntId
                                     select r.StrRoleName).ToListAsync();

                List < Claim > claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, loginObject.Email),
                    new Claim(ClaimTypes.Email, loginObject.Email),
                };

                Role.ForEach(item =>
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                });


                //ClaimsIdentity identity = new ClaimsIdentity(claims,"Cookies");
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);


                // Je page er jonno Http Request korechi sei URL er jonno (URL a kono ekta Req korle./ menu theke req korle)
                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }

                else // Default Request er jonno  => Project Run korle
                {
                    string role = "";
                    var loggedInUser = HttpContext.User;
                    if (loggedInUser.Identity.IsAuthenticated)
                    {
                        role = loggedInUser.FindFirstValue(ClaimTypes.Role);
                    }

                    if(role == "SuperAdmin")
                    {
                        return RedirectToAction("SuperAdmin", "Home");
                    }
                    else if (role == "Admin")
                    {
                        return RedirectToAction("SuperAdmin", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
               
            return RedirectToAction("Login", "Auth");
        }

    }
}
