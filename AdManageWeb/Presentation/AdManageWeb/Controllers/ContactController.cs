using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
