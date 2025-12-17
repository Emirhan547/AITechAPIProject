using AITech.WebUI.DTOs.BannerDtos;
using AITech.WebUI.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.Home_Index
{
    public class _HomeHeroViewComponent(IBannerService _bannerService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banners = await _bannerService.GetAllAsync();
            var activeBanner = banners.FirstOrDefault(x => x.IsActive);

            return View(activeBanner);
        }
    }
}
