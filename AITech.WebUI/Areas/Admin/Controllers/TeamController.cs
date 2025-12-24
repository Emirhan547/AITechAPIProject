using AITech.WebUI.DTOs.TeamDtos;
using AITech.WebUI.Services.SocialServices;
using AITech.WebUI.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController(ITeamService _teamService) : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            var teams = await _teamService.GetAllAsync();
            return View(teams);
        }
        public async Task<IActionResult> CreateTeam()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createTeamDto);
            }
            await _teamService.CreateAsync(createTeamDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            return View(team);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateTeamDto);

            }
            await _teamService.UpdateAsync(updateTeamDto);
            return RedirectToAction("Index");
        }
    }
}