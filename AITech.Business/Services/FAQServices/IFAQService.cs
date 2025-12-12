using AITech.Business.Services.GenericServices;
using AITech.DTO.DTOs.FAQDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.IFAQServices
{
    public interface IFAQService:IGenericService<ResultFAQDto,CreateFAQDto,UpdateFAQDto>
    {
    }
}
