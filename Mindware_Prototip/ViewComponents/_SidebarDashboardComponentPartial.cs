using Microsoft.AspNetCore.Mvc;

namespace Mindware_Prototip.ViewComponents
{
    public class _SidebarDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
