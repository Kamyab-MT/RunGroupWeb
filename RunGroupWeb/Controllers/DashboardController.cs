using Microsoft.AspNetCore.Mvc;

namespace RunGroupWeb.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
