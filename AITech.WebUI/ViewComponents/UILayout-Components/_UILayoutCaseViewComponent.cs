using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.UILayout_Components
{
    public class _UILayoutCaseViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
