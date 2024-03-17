using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
