using AITech.DataAccess.Repositories.TeamRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.DTOs.TeamDtos;
using AITech.Entity.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.TeamServices
{
    public class TeamService (ITeamRepository _teamRepository,IUnitOfWork _unitOfWork): ITeamService
    {
        public async Task TCreateAsync(CreateTeamDto createDto)
        {
            var team = createDto.Adapt<Team>();
            await _teamRepository.CreateAsync(team);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var teams=await _teamRepository.GetByIdAsync(id);
            if (teams == null)
            {
                throw new Exception("Takım Üyesi Bulunamadı");
            }
            _teamRepository.Delete(teams);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultTeamDto>> TGetAllAsync()
        { 
            var teams=await _teamRepository.GetAllAsync();
            return teams.Adapt<List<ResultTeamDto>>();
        }

        public async Task<ResultTeamDto> TGetByIdAsync(int id)
        {
            var teams=await _teamRepository.GetByIdAsync(id);
            return teams.Adapt<ResultTeamDto>();
        }

        public async Task<List<ResultTeamDto>> TGetTeamsWithSocialsAsync()
        {
            var teams=await _teamRepository.GetTeamsWithSocialsAsync();
            return teams.Adapt<List<ResultTeamDto>>();
        }

        public async Task TUpdateAsync(UpdateTeamDto updateDto)
        {
           var teams=updateDto.Adapt<Team>();
           _teamRepository.Update(teams);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
