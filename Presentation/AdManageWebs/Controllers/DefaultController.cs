using Microsoft.AspNetCore.Mvc;

namespace AdManageWebs.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
