using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Areas.Register.Controllers
{
    public class LoginController : Controller
    {
        [Area("UserProcedures")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
