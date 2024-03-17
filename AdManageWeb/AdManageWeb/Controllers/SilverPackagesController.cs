using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
{
    public class SilverPackagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
