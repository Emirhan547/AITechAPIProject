using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.UILayout
{
    public class _UILayoutNavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke ()
        {
            return View();
        }
    }
}
