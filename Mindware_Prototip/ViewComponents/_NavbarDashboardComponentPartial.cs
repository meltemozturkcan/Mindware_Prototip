using Microsoft.AspNetCore.Mvc;

namespace Mindware_Prototip.ViewComponents
{
    public class _NavbarDashboardComponentPartial:ViewComponent
    {
      
     public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
