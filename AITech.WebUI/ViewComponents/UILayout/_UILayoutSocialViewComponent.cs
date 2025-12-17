using AITech.WebUI.Services.SocialServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.UILayout
{
    public class _UILayoutSocialViewComponent(ISocialService _socialService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socials = await _socialService.GetAllAsync();
            return View(socials);
        }
    }
}
