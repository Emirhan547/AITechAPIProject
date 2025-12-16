using AITech.WebUI.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents.UILayout_Components
{
    public class _UILayoutTestimonialViewComponent(ITestimonialService _testimonialService):ViewComponent
    {
        public async Task<IViewComponentResult> Invoke()
        {
            var testimonials=await _testimonialService.GetAllAsync();
            return View(testimonials);
        }
    }
}
