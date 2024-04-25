using Microsoft.AspNetCore.Mvc;

namespace AdManageWebs.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
