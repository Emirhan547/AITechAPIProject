
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
            var features = await _client.GetFromJsonAsync<List<ResultSocialDto>>("features");
             return features;
        }

        public async Task<UpdateSocialDto> GetByIdAsync(int id)
        {
            var features = await _client.GetFromJsonAsync<UpdateSocialDto>("features/" + id);
            return features;
        }

        public async Task UpdateAsync(UpdateSocialDto update)
        {
            await _client.PutAsJsonAsync("features",update);
        }
    }
}
