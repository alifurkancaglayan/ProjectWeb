using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Login(model);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanici adi veya parola hatali!");
                    return View();
                }

                var operationClaims = _userService.GetClaims(user.Id);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                };
                foreach (var role in operationClaims)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }

                var userIdentity = new ClaimsIdentity(claims, "a");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                foreach (var role in operationClaims)
                {
                    if (role.Name == "admin")
                        return Redirect("/Admin/Home/Index");
                    else if (role.Name == "user")
                        return Redirect("/Home/Index");
                }

            }
            return View();
        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
