using AITech.WebUI.DTOs.FAQDtos;
using AITech.WebUI.Services.FAQsServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.Home_Index
{
    public class _HomeFaqViewComponent(IFAQService _fAQService):ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var faqs = await _fAQService.GetAllAsync();
            return View(faqs);
        }
    }
}
