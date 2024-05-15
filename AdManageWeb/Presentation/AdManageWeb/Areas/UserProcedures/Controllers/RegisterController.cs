using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Areas.UserProcedures.Controllers
{
    public class RegisterController : Controller
    {
        [Area("UserProcedures")]
            public IActionResult Register()
        {
            return View();
        }
    }
}
