using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
