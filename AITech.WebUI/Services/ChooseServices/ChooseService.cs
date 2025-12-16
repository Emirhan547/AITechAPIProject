using AITech.WebUI.DTOs.ChooseDtos;
using System.Net.Http;

namespace AITech.WebUI.Services.ChooseServices
{
    public class ChooseService : IChooseService
    {
        private readonly HttpClient _client;

        public ChooseService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7149/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateChooseDto create)
        {
            await _client.PostAsJsonAsync("Chooses",create);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Chooses/" + id);
        }

        public async Task<List<ResultChooseDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultChooseDto>>("Chooses");
        }

        public async Task<UpdateChooseDto> GetByIdAsync(int id)
        {
            var chooses = await _client.GetFromJsonAsync<UpdateChooseDto>("Chooses/" + id);
            return chooses;
        }

        public async Task UpdateAsync(UpdateChooseDto update)
        {
            await _client.PutAsJsonAsync("Chooses",update);
        }
    }
}
