using AITech.DTO.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.DTOs.ProjectDtos
{
    public record ResultProjectDto(
        int Id,
        string Title,
        string ImageUrl,
        int CategoryId,
        ResultCategoryDto Category
    );

}
