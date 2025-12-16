using AITech.Business.Services.AboutServices;
using AITech.DTO.DTOs.AboutDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService _aboutService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var abouts=await _aboutService.TGetAllAsync();
            return Ok(abouts);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateAboutDto craeteAbout)
        {
            await _aboutService.TCreateAsync(craeteAbout);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var abouts=await _aboutService.TGetByIdAsync(id);
            return Ok(abouts);
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateAboutDto updateAbout)
        {
             await _aboutService.TUpdateAsync(updateAbout);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _aboutService.TDeleteAsync(id);
            return NoContent();

        }
    }
}
