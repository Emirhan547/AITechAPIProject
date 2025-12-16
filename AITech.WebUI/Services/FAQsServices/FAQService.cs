using AITech.WebUI.DTOs.FAQDtos;

namespace AITech.WebUI.Services.FAQsServices
{
    public class FAQService : IFAQService
    {
        private readonly HttpClient _client;

        public FAQService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7149/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateFAQDto create)
        {
            await _client.PostAsJsonAsync("Faqs",create);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Faqs/" + id);
        }

        public async Task<List<ResultFAQDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultFAQDto>>("Faqs");
        }

        public async Task<UpdateFAQDto> GetByIdAsync(int id)
        {
            var faqs = await _client.GetFromJsonAsync<UpdateFAQDto>("Faqs/" + id);
            return faqs;
        }

        public async Task UpdateAsync(UpdateFAQDto update)
        {
            await _client.PutAsJsonAsync("Faqs",update);
        }
    }
}
