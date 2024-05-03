using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Areas.Member.Controllers
{
    [Area("Member")]
    public class SellController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
