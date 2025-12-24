
using AITech.WebUI.DTOs.SocialDtos;

namespace AITech.WebUI.Services.SocialServices
{
    public class SocialService : ISocialService
    {
        private readonly HttpClient _client;

        public SocialService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7149/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateSocialDto create)
        {
            await _client.PostAsJsonAsync("socials",create);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("socials/" + id);
        }

        public async Task<List<ResultSocialDto>> GetAllAsync()
        {
            var socials = await _client.GetFromJsonAsync<List<ResultSocialDto>>("socials");
             return socials;
        }

        public async Task<UpdateSocialDto> GetByIdAsync(int id)
        {
            var socials = await _client.GetFromJsonAsync<UpdateSocialDto>("socials/" + id);
            return socials;
        }

        public async Task UpdateAsync(UpdateSocialDto update)
        {
            await _client.PutAsJsonAsync("socials", update);
        }
    }
}
