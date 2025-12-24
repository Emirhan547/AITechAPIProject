using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.DTOs.TeamDtos
{
    public record CreateTeamDto(string? Name, string? Title,string? Description, string? ImageUrl, int SocialId);

}
