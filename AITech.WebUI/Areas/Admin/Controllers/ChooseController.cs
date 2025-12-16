using AITech.WebUI.DTOs.ChooseDtos;
using AITech.WebUI.Services.ChooseServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    public class ChooseController(IChooseService _chooseService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var choose=await _chooseService.GetAllAsync();
            return View(choose);
        }
        public IActionResult CreateChoose()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>CreateChoose(CreateChooseDto createChoose)
        {
            await _chooseService.CreateAsync(createChoose);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>UpdateChoose(int id)
        {
            var choose=await _chooseService.GetByIdAsync(id);
            return View(choose);
        }
        [HttpPost]
        public async Task<IActionResult>UpdateChoose(UpdateChooseDto updateChoose)
        {
            await _chooseService.UpdateAsync(updateChoose);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>DeleteChoose(int id)
        {
            await _chooseService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
