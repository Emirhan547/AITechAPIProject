using AITech.WebUI.DTOs.TestimonialDtos;
using AITech.WebUI.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents.Home_Index
{
    public class _HomeTestimonialViewComponent(ITestimonialService _testimonialService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _testimonialService.GetAllAsync();
            return View(testimonials);
        }
    }
}
