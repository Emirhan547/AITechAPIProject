using AITech.WebUI.DTOs.ChooseDtos;
using AITech.WebUI.Services.ChooseServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.Home_Index
{
    public class _HomeFeatureViewComponent(IChooseService _chooseService):ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var chooseList = await _chooseService.GetAllAsync();
            var choose = chooseList?.FirstOrDefault();

            if (choose == null)
            {
                return Content("");
            }

            return View(choose);
        }
    }
}
