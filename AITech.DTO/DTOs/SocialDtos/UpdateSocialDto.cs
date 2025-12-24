using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.DTOs.SocialDtos
{
    public record UpdateSocialDto(int Id, string? Name, string? Url, string? Icon, int TeamId);

}
