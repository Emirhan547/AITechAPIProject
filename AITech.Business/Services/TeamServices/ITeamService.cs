using AITech.Business.Services.GenericServices;
using AITech.DTO.DTOs.TeamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.TeamServices
{
    public interface ITeamService:IGenericService<ResultTeamDto,CreateTeamDto,UpdateTeamDto>
    {
        Task<List<ResultTeamDto>> TGetTeamsWithSocialsAsync();
    }
}
