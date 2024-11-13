using System.Web.Mvc;
using KOI_POND_WEB.Models;
using KOI_POND_WEB.Services;
using KOI_POND_WEB.Services.Interfaces;
using KOI_POND_WEB.ViewModels;

public class AccountController : Controller
{
    private readonly ILoginService _loginService;

    public AccountController()
    {
        _loginService = new LoginService(new KoiPondDbContext());
    }

    // Trang đăng nhập
    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    // Xử lý đăng nhập
    [HttpPost]
    public ActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _loginService.Login(model.Username, model.Password);

            if (user != null)
            {
                Session["UserId"] = user.Id;
                Session["Username"] = user.Username;
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }
        }

        return View(model);
    }

    // Đăng xuất
    public ActionResult Logout()
    {
        Session.Clear();
        return RedirectToAction("Login", "Account");
    }
}
