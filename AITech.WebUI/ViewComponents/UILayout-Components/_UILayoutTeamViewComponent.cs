using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.UILayout_Components
{
    public class _UILayoutTeamViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        } 
    }
}
