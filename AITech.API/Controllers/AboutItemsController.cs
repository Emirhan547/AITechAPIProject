using AITech.Business.Services.AboutItemServices;
using AITech.DTO.DTOs.AboutDtos;
using AITech.DTO.DTOs.AboutItemDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutItemsController(IAboutItemService _aboutItemService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var response=await _aboutItemService.TGetAllAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var response=await _aboutItemService.TGetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateAboutItemDto createAboutItemDto)
        {
             await _aboutItemService.TCreateAsync(createAboutItemDto);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateAboutItemDto aboutItemDto)
        {
            await _aboutItemService.TUpdateAsync(aboutItemDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _aboutItemService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
