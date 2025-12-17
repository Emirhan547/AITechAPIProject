using AITech.WebUI.DTOs.AboutItems;
using AITech.WebUI.Services.AboutItemServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutItemController(IAboutItemService _aboutItem): Controller
    {
        public async Task<IActionResult> Index()
        {
            var aboutItems=await _aboutItem.GetAllAsync();
            return View(aboutItems);
        }
        public IActionResult CreateAboutItem()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutItem(CreateAboutItemDto aboutItemDto)
        {
            await _aboutItem.CreateAsync(aboutItemDto);
            return View(aboutItemDto);
        }
        public async Task<IActionResult>UpdateAboutItem(int id)
        {
            var abouts = await _aboutItem.GetByIdAsync(id);
            return View(abouts);
        }
        [HttpPost]
        public async Task<IActionResult>UpdateAboutItem(UpdateAboutItemDto aboutItemDto)
        {
            await _aboutItem.UpdateAsync(aboutItemDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>DeleteAboutItem(int id)
        {
            await _aboutItem.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
