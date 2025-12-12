using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.DTOs.BannerDtos
{
    public record UpdateBannerDto(int Id, string Title, string ImageUrl, string Description, bool IsActive);

}
