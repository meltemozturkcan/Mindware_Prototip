using Microsoft.AspNetCore.Mvc;

namespace Mindware_Prototip.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
