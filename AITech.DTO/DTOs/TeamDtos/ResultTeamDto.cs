using AITech.DTO.DTOs.SocialDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.DTOs.TeamDtos
{
    public record ResultTeamDto(int Id, string Name, string Title,string Description, string ImageUrl, int SocialId, ResultSocialDto Social, DateTime CreatedDate, DateTime UpdatedDate);
    }


