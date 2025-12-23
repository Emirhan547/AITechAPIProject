using AITech.WebUI.DTOs.TeamDtos;
using AITech.WebUI.Services.SocialServices;
using AITech.WebUI.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController(ITeamService _teamService, ISocialService _socialService) : Controller
    {
        private async Task GetSocialsAsync()
        {
            var socialList = await _socialService.GetAllAsync();
            ViewBag.Socials = (from social in socialList
                               select new SelectListItem
                               {
                                   Text = social.Name,
                                   Value = social.Id.ToString()
                               }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var teams = await _teamService.GetAllAsync();
            return View(teams);
        }
        public async Task<IActionResult> CreateTeam()
        {
            await GetSocialsAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
        {
            if (ModelState.IsValid)
            {
                await GetSocialsAsync();
                return View(createTeamDto);
            }
            await _teamService.CreateAsync(createTeamDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateTeam(int id)
        {
            await GetSocialsAsync();
            var team = await _teamService.GetByIdAsync(id);
            return View(team);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            if (ModelState.IsValid)
            {
                await GetSocialsAsync();
                return View(updateTeamDto);

            }
            await _teamService.UpdateAsync(updateTeamDto);
            return RedirectToAction("Index");
        }
    }
}