using AITech.WebUI.DTOs.FAQDtos;
using AITech.WebUI.Services.FAQsServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    public class FAQController(IFAQService _fAQService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var faqs=await _fAQService.GetAllAsync();
            return View(faqs);
        }
        public IActionResult CreateFaq()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>CreateFaq(CreateFAQDto createFAQDto)
        {
            await _fAQService.CreateAsync(createFAQDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>UpdateFaq(int id)
        {
            var faqs= await _fAQService.GetByIdAsync(id);
            return View(faqs);
        }
        public async Task<IActionResult>UpdateFaq(UpdateFAQDto updateFAQDto)
        {
            await _fAQService.UpdateAsync(updateFAQDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>DeleteFaq(int id)
        {
            await _fAQService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
