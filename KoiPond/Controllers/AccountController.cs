using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiPond.Services;
using KoiPond.Repositories.ViewModels;

namespace KoiPond.Controllers
{
	/*Old Controller
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManage;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManage)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManage = roleManage;
		}

		[HttpGet]
		public IActionResult Login()
		{
			var roleSelected = _roleManage.Roles.ToList();
			ViewBag.lstRole = new SelectList(roleSelected, "Name", "Name");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			}

			var roleSelected = _roleManage.Roles.ToList();
			ViewBag.lstRole = new SelectList(roleSelected, "Name", "Name");
			return View("Login", model);
		}

		[HttpPost]
		public async Task<IActionResult> Register(LoginViewModel model, string roleName, string returnUrl = null)
		{
			if (ModelState.IsValid)
			{
				var user = new IdentityUser { UserName = model.Email, Email = model.Email };
				var result = await _userManager.CreateAsync(user, model.Password);
				var Ref_role = await _roleManage.FindByNameAsync(model.RoleName);
				if (Ref_role == null)
				{
					var roleNew = new IdentityRole
					{
						Name = roleName,
					};
					var result_role = await _roleManage.CreateAsync(roleNew);

					var result_AddUserInRole = await _userManager.AddToRoleAsync(user, roleNew.Name);

					foreach (var err in result_role.Errors)
					{
						ModelState.AddModelError("", err.Description);
					}

					foreach (var err in result_AddUserInRole.Errors)
					{
						ModelState.AddModelError("", err.Description);
					}
				}
				else
				{
					var result_AddUserInRole = await _userManager.AddToRoleAsync(user, model.RoleName);
					foreach (var err in result_AddUserInRole.Errors)
					{
						ModelState.AddModelError("", err.Description);
					}
				}

				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					if (Url.IsLocalUrl(returnUrl))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			ViewData["ReturnUrl"] = returnUrl;
			var roleSelected = _roleManage.Roles.ToList();
			ViewBag.lstRole = new SelectList(roleSelected, "Name", "Name");
			return View("Login", model); // You can also create a separate Register view if needed.
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
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
				var user = await _userManager.FindByNameAsync(model.Email);

				if (user == null)
				{
					ModelState.AddModelError("", "Something is wrong!");
					return View(model);
				}
				else
				{
					return RedirectToAction("PasswordChange", "Account", new { username = user.UserName });
				}
			}
			return View(model);
		}

		public IActionResult PasswordChange(string username)
		{
			if (string.IsNullOrEmpty(username))
			{
				return RedirectToAction("ForgotPassword", "Account");
			}
			return View(new ChangePasswordViewModel { Email = username });
		}

		[HttpPost]
		public async Task<IActionResult> PasswordChange(ChangePasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.Email);

				if (user != null)
				{
					var result = await _userManager.RemovePasswordAsync(user);
					if (result.Succeeded)
					{
						result = await _userManager.AddPasswordAsync(user, model.Password);
						return RedirectToAction("login", "account");
					}
					else
					{
						foreach (var change in result.Errors)
						{
							ModelState.AddModelError("", change.Description);
						}
					}
					return View(model);
				}
				else
				{
					ModelState.AddModelError("", "Email not found");
					return View(model);
				}
			}
			ModelState.AddModelError("", "Something went wrong!");
			return View(model);
		}
	}
}*/
	 
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
