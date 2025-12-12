using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.DTOs.AboutDtos
{
    public record ResultAboutDto(int Id, string Title, string ImageUrl, DateTime CreatedDate, DateTime UpdatedDate);
}


