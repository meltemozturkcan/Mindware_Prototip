using Microsoft.AspNetCore.Mvc;

namespace Mindware_Prototip.ViewComponents
{
    public class _RightSidebarDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
