using AITech.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AITech.WebUI.Controllers
{
    public class HomeController() : Controller
    {

        public IActionResult Index()
        {
            
            return View();

        }

    }
}
