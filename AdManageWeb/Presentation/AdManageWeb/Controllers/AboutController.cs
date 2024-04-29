using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
