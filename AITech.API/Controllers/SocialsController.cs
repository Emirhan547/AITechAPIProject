using AITech.Business.Services.SocialServices;
using AITech.DTO.DTOs.SocialDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialsController(ISocialService _socialService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response=await _socialService.TGetAllAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var response=await _socialService.TGetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateSocialDto createSocialDto)
        {
            await _socialService.TCreateAsync(createSocialDto);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateSocialDto updateSocialDto)
        {
            await _socialService.TUpdateAsync(updateSocialDto);
            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _socialService.TDeleteAsync(id);
            return Ok();
        }

    }
}
