using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.UILayout
{
    public class _UILayoutScriptsViewComponent:ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
