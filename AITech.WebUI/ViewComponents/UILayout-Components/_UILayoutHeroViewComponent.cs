using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.UILayout_Components
{
    public class _UILayoutHeroViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
