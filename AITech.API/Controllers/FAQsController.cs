using AITech.Business.Services.IFAQServices;
using AITech.DTO.DTOs.FAQDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQsController(IFAQService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var response=await _service.TGetAllAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var response=await _service.TGetByIdAsync(id);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateFAQDto updateDto)
        {
            await _service.TUpdateAsync(updateDto);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateFAQDto createDto)
        {
            await _service.TCreateAsync(createDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _service.TDeleteAsync(id);
            return NoContent();
        }
    }
}
