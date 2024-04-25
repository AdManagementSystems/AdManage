
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdManageWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Test()
        {
            return View();
        }
		public IActionResult TestAdmin()
        {
            return View();
        }
        public IActionResult TestClient()
        {
            return View();
        }

        public IActionResult Privacy()
		{
			return View();
		}
	}
}
