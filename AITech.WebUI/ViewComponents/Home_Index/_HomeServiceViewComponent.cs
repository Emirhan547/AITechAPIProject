using AITech.WebUI.DTOs.FeatureDtos;
using AITech.WebUI.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.Home_Index
{
    public class _HomeServiceViewComponent(IFeatureService _featureService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _featureService.GetAllAsync();
            return View(result);
        }
    }
}
