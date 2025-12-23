using AITech.Business.Services.TeamServices;
using AITech.DTO.DTOs.TeamDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController(ITeamService _teamService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var teams=await _teamService.TGetAllAsync();
            return Ok(teams);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var teams=await _teamService.TGetByIdAsync(id);
            return Ok(teams);
        }
        [HttpGet("WithSocials")]
        public async Task<IActionResult> GetAllWithSocials()
        {
            var teams = await _teamService.TGetTeamsWithSocialsAsync();
            return Ok(teams);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateTeamDto createTeamDto)
        {
            await _teamService.TCreateAsync(createTeamDto);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateTeamDto updateTeamDto)
        {
            await _teamService.TUpdateAsync(updateTeamDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _teamService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
