using AITech.WebUI.Services.AboutItemServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.Home_Index
{
    public class _HomeAboutItemViewComponent(IAboutItemService _aboutItemService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _aboutItemService.GetAllAsync();
            return View(items);
        }
    }
}
