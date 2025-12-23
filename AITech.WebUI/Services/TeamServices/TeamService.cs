using AITech.WebUI.DTOs.TeamDtos;

namespace AITech.WebUI.Services.TeamServices
{
    public class TeamService: ITeamService
    {
        private readonly HttpClient _client;

        public TeamService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7149/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateTeamDto create)
        {
            await _client.PostAsJsonAsync("teams", create);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("teams/" + id);
        }

        public async Task<List<ResultTeamDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultTeamDto>>("teams/WithSocials");
        }

        public async Task<UpdateTeamDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateTeamDto>("teams/" + id);
        }

        public async Task UpdateAsync(UpdateTeamDto update)
        {
            await _client.PutAsJsonAsync("teams", update);
        }
    }
}
