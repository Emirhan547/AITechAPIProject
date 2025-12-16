

using AITech.WebUI.DTOs.TestimonialDtos;

namespace AITech.WebUI.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly HttpClient _client;

        public TestimonialService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7149/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateTestimonialDto create)
        {
            await _client.PostAsJsonAsync("testimonials",create);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("testimonials/" + id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllAsync()
        {
            var testimonials = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("testimonials");
            return testimonials;
        }

        public async Task<UpdateTestimonialDto> GetByIdAsync(int id)
        {
            var testimonials = await _client.GetFromJsonAsync<UpdateTestimonialDto>("testimonials/" + id);
            return testimonials;
        }

        public async Task UpdateAsync(UpdateTestimonialDto update)
        {
            await _client.PutAsJsonAsync("testimonials", update);
        }
    }
}
