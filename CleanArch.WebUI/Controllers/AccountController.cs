using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
