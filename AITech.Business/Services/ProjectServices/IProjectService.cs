using AITech.Business.Services.GenericServices;
using AITech.DTO.DTOs.ProjectDtos;
using AITech.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.ProjectServices
{
    public interface IProjectService:IGenericService<ResultProjectDto,CreateProjectDto,UpdateProjectDto>
    {
        Task<List<ResultProjectDto>> TGetProjectsWithCategoriesAsync();
    }
}
