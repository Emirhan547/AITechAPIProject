using AITech.Business.Services.ChooseServices;
using AITech.DTO.DTOs.ChooseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoosesController (IChooseService _chooseService): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var response=await _chooseService.TGetAllAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var response = await _chooseService.TGetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateChooseDto createChooseDto)
        {
            await _chooseService.TCreateAsync(createChooseDto);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateChooseDto updateChooseDto)
        {
            await _chooseService.TUpdateAsync(updateChooseDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _chooseService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
