using AITech.WebUI.DTOs.FeatureDtos;
using AITech.WebUI.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController(IFeatureService _featureService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var features=await _featureService.GetAllAsync();
            return View(features);
        }
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createFeatureDto);
            }
            await _featureService.CreateAsync(createFeatureDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var updateFeatures=await _featureService.GetByIdAsync(id);
            return View(updateFeatures);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateFeatureDto);
            }
            await _featureService.UpdateAsync(updateFeatureDto);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> DeleteFeature(int id)
        {
            await _featureService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
