using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
{
    public class BronzePackagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
