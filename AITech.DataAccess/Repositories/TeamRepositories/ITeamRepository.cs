using AITech.DataAccess.Repositories.GenericRepositories;
using AITech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DataAccess.Repositories.TeamRepositories
{
    public interface ITeamRepository:IRepository<Team>
    {
        Task<List<Team>> GetTeamsWithSocialsAsync();
    }
}
