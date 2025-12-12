using AITech.WebUI.Models;
using AITech.WebUI.Services.OpenAIServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AITech.WebUI.Controllers
{
    public class HomeController(IOpenaiService _openaiService) : Controller
    {

        public async Task<IActionResult>Index(string prompt)
        {
            var response=await _openaiService.GetGeminiDataAsync(prompt);
            if(string.IsNullOrEmpty(prompt))
            {
                ViewBag.Response = response;
            }
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
