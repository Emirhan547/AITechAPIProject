using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Controllers
{
    public class BannerController(HttpClient _httpClient) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
