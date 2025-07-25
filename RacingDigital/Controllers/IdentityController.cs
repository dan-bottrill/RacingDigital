using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RacingDigital.Areas.Identity.Models;
using RacingDigital.Areas.Identity.NewFolder;

namespace RacingDigital.Controllers
{
    public class IdentityController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;

        public IdentityController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Home");
        }
    }
}
