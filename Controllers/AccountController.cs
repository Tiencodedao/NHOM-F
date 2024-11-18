using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiPond.Services;
using KoiPond.Repositories.ViewModels;

namespace KoiPond.Controllers
{ 
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var roleSelected = await _userService.GetAllRoleAsync();
            ViewBag.lstRole = new SelectList(roleSelected, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            var roleSelected = await _userService.GetAllRoleAsync();
            ViewBag.lstRole = new SelectList(roleSelected, "Name", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model, string roleName, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model, roleName);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            var roleSelected = await _userService.GetAllRoleAsync();
            ViewBag.lstRole = new SelectList(roleSelected, "Name", "Name");
            return View("Login", model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ForgotPasswordAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("PasswordChange", new { username = model.Email });
                }
                ModelState.AddModelError("", "Unable to process forgot password request.");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult PasswordChange(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("ForgotPassword");
            }
            return View(new ChangePasswordViewModel { Email = username });
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
