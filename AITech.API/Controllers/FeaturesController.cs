using AITech.Business.Services.FeatureServices;
using AITech.DTO.DTOs.FeatureDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IFeatureService _featureService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var response=await _featureService.TGetAllAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var response = await _featureService.TGetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateFeatureDto createFeature)
        {
            await _featureService.TCreateAsync(createFeature);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.TUpdateAsync(updateFeatureDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _featureService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
