using AITech.WebUI.DTOs.AboutItems;
using System.Net.Http.Json;

namespace AITech.WebUI.Services.AboutItemServices
{
    public class AboutItemService:IAboutItemService
    {
        private readonly HttpClient _httpClient;

        public AboutItemService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7149/api/");
            _httpClient = httpClient;
        }

        public async Task<List<ResultAboutItemDto>> GetAllAsync()
        {
            var aboutItems = await _httpClient.GetFromJsonAsync<List<ResultAboutItemDto>>("AboutItems");
            return aboutItems;
        }

        public async Task<UpdateAboutItemDto> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateAboutItemDto>("AboutItems/" + id);
        }

        public async Task CreateAsync(CreateAboutItemDto create)
        {
            await _httpClient.PostAsJsonAsync("AboutItems", create);
        }

        public async Task UpdateAsync(UpdateAboutItemDto update)
        {
            await _httpClient.PutAsJsonAsync("AboutItems",update);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync("AboutItems/" + id);
        }


    }
}
