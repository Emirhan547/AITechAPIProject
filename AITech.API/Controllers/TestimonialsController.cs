using AITech.Business.Services.TestimonialServices;
using AITech.DTO.DTOs.TestimonialDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(ITestimonialService _testimonialService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var response=await _testimonialService.TGetAllAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var response=await _testimonialService.TGetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateTestimonialDto testimonialDto)
        {
            await _testimonialService.TCreateAsync(testimonialDto);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateTestimonialDto testimonialDto)
        {
            await _testimonialService.TUpdateAsync(testimonialDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _testimonialService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
