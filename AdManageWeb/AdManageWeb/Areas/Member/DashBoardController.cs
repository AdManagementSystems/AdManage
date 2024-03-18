using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Areas.Member
{
    [Area("Member")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
