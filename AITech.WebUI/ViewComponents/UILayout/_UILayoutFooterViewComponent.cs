using AITech.WebUI.DTOs.SocialDtos;
using AITech.WebUI.Services.SocialServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.UILayout
{
    public class _UILayoutFooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           return View();
        }
    }
}
