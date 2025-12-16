using AITech.WebUI.DTOs.TestimonialDtos;
using AITech.WebUI.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    public class TestimonialController(ITestimonialService _testimonialService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var testimonials=await _testimonialService.GetAllAsync();
            return View(testimonials);
        }
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialService.CreateAsync(createTestimonialDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimoniasl=await _testimonialService.GetByIdAsync(id);
            return View(testimoniasl);
        }
        [HttpPost]
        public async Task<IActionResult>UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.UpdateAsync(updateTestimonialDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
