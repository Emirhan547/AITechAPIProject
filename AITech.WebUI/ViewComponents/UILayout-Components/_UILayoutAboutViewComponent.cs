using AITech.WebUI.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.UILayout_Components
{
    public class _UILayoutAboutViewComponent(IAboutService _aboutService):ViewComponent
    {
        public async Task<IViewComponentResult>InvokeAsync()
        {
            var abouts=await _aboutService.GetAllAsync();
            return View(abouts);
        }

    }
}
