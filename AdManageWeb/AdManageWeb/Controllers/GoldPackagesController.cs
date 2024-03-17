using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
{
    public class GoldPackagesController : Controller
    {
        public IActionResult PackagesGold()
        {
            return View();
        }
    }
}
