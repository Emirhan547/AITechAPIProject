using AITech.WebUI.DTOs.SocialDtos;
using AITech.WebUI.Services.SocialServices;
using AITech.WebUI.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialController(ISocialService _socialService, ITeamService _teamService) : Controller
    {
        private async Task LoadTeamsAsync()
        {
            var teamList = await _teamService.GetAllAsync();
            ViewBag.Teams = teamList
                .Select(team => new SelectListItem
                {
                    Text = team.Name,
                    Value = team.Id.ToString()
                })
                .ToList();
        }
        public async Task<IActionResult> Index()
        {
            var socials = await _socialService.GetAllAsync();
            var teams = await _teamService.GetAllAsync();
            ViewBag.TeamNames = teams.ToDictionary(team => team.Id, team => team.Name);
            return View(socials);
        }
        public async Task<IActionResult> CreateSocial()
        {
            await LoadTeamsAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocial(CreateSocialDto createSocial)
        {
            if (!ModelState.IsValid)
            {
                await LoadTeamsAsync();
                return View(createSocial);
            }
            await _socialService.CreateAsync(createSocial);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateSocial(int id)
        {
            await LoadTeamsAsync();
            var socials=await _socialService.GetByIdAsync(id);
            return View(socials);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocial(UpdateSocialDto updateSocial)
        {
            if (!ModelState.IsValid)
            {
                await LoadTeamsAsync();
                return View(updateSocial);
            }
            await _socialService.UpdateAsync(updateSocial);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>DeleteSocial(int id)
        {
            await _socialService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
