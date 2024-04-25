using Microsoft.AspNetCore.Mvc;

namespace AdManageWebs.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
