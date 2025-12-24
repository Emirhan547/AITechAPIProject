using AITech.WebUI.DTOs.SocialDtos;
using AITech.WebUI.Services.SocialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialController(ISocialService _socialService): Controller
    {
        public async Task<IActionResult> Index()
        {
            var socials=await _socialService.GetAllAsync();
            return View(socials);
        }
        public IActionResult CreateSocial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocial(CreateSocialDto createSocial)
        {
            if (!ModelState.IsValid)
            {
                return View(createSocial);
            }
            await _socialService.CreateAsync(createSocial);
            return RedirectToAction("Index");
        }
       public async Task<IActionResult> UpdateSocial(int id)
        {
            var socials=await _socialService.GetByIdAsync(id);
            return View(socials);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocial(UpdateSocialDto updateSocial)
        {
            if (!ModelState.IsValid)
            {
                return View(updateSocial);
            }
            await _socialService.UpdateAsync(updateSocial);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>DeleteSocial(int id)
        {
            await _socialService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
