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

                List<Claim> claims = new List<Claim>
                {
                   new Claim(ClaimTypes.NameIdentifier, UserInfo.IntId.ToString()),
                   //new Claim(ClaimTypes.NameIdentifier,UserInfo.StrEmail),
                   new Claim(ClaimTypes.Email, UserInfo.StrEmail),
                   new Claim(ClaimTypes.Name, UserInfo.StrFullName)
                };

                //Role.ForEach(item =>
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, item));
                //});
                claims.AddRange(Role.Select(item => new Claim(ClaimTypes.Role, item)));


                //ClaimsIdentity identity = new ClaimsIdentity(claims,"Cookies");
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                var principalClaimsBeforeSignIn = principal.Claims.ToList();
                foreach (var claim in principalClaimsBeforeSignIn)
                {
                    Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
                }

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);


                var principalClaimsAfterSignIn = HttpContext.User.Claims.ToList();
                foreach (var claim in principalClaimsAfterSignIn)
                {
                    Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
                }


                // Je page er jonno Http Request korechi sei URL er jonno (URL a kono ekta Req korle./ menu theke req korle)
                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }


                else //Access Denied hoile Auth/Login a direct hoy (Configure theika). tokhon return URL ta null niya ase.
                {

                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Login", "Auth");
        }

    }
}
