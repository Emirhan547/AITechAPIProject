using AITech.WebUI.DTOs.ProjectDtos;
using AITech.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.ViewComponents.Home_Index
{
    public class _HomeCaseViewComponent(IProjectService _projectService):ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var projects = await _projectService.GetAllAsync();
            return View(projects.Take(3).ToList());
        }
    }
}
