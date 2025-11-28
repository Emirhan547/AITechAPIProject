using AITech.WebUI.DTOs.ProjectDtos;

namespace AITech.WebUI.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {

        private readonly HttpClient _client;

        public ProjectService (HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7149/api/");

            _client = client;
        }

        public async Task CreateAsync(CreateProjectDto createProjectDto)
        {
            await _client.PostAsJsonAsync("projects", createProjectDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("projects/" + id);
        }

        public async Task<List<ResultProjectDto>> GetAllAsync()
        {
           return await _client.GetFromJsonAsync<List<ResultProjectDto>>("projects/WithCategories");
        }

        public async Task<UpdateProjectDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateProjectDto>("projects/" + id);
        }

        public async Task UpdateAsync(UpdateProjectDto updateProjectDto)
        {
            await _client.PutAsJsonAsync("projects", updateProjectDto);
        }
    }
}
