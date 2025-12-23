using AITech.WebUI.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents.Home_Index
{
    public class _HomeTeamViewComponent(ITeamService _teamService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var teams=await _teamService.GetAllAsync();
            return View(teams);
        } 
    }
}
