using AITech.WebUI.DTOs.TeamDtos;
using AITech.WebUI.Services.GenericServices;

namespace AITech.WebUI.Services.TeamServices
{
    public interface ITeamService:IGenericService<ResultTeamDto,CreateTeamDto,UpdateTeamDto>
    {
    }
}
