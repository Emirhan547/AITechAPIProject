using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.UILayout_Components
{
    public class _UILayoutHeadViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
