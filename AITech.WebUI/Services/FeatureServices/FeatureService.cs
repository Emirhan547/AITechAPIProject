using AITech.WebUI.DTOs.FeatureDtos;

namespace AITech.WebUI.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _client;

        public FeatureService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7149/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateFeatureDto create)
        {
            await _client.PostAsJsonAsync("features",create);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("features/"+id);
        }

        public async Task<List<ResultFeatureDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultFeatureDto>>("features");
        }

        public async Task<UpdateFeatureDto> GetByIdAsync(int id)
        {
            var features = await _client.GetFromJsonAsync <UpdateFeatureDto>("features/" + id);
            return features;
        }

        public async Task UpdateAsync(UpdateFeatureDto update)
        {
            await _client.PutAsJsonAsync("features",update);
        }
    }
}
