using AITech.WebUI.Models;
using AITech.WebUI.Services.AboutItemServices;
using AITech.WebUI.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.Home_Index

{ 
    public class _HomeAboutViewComponent(IAboutService _aboutService):ViewComponent
    {
        public async Task<IViewComponentResult>InvokeAsync()
        {
            var abouts = await _aboutService.GetAllAsync();
            var about = abouts?.FirstOrDefault();   // ✅ null-safe

    return View(about);
        }
    }

    }

