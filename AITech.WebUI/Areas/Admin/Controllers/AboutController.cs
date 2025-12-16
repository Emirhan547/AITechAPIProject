using AITech.WebUI.DTOs.AboutDtos;
using AITech.WebUI.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    public class AboutController(IAboutService _aboutService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var abouts=await _aboutService.GetAllAsync();
            return View(abouts);
        }

        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>CreateAbout(CreateAboutDto about)
        {
            await _aboutService.CreateAsync(about);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>UpdateAbout(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            return View(about);
        }
        [HttpPost]
        public async Task<IActionResult>UpdateAbout(UpdateAboutDto updateAbout)
        {
            await _aboutService.UpdateAsync(updateAbout);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>DeleteAbout(int id)
        {
            await _aboutService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
