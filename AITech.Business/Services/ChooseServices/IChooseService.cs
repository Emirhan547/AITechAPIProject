using AITech.Business.Services.GenericServices;
using AITech.DTO.DTOs.ChooseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.ChooseServices
{
    public interface IChooseService:IGenericService<ResultChooseDto,CreateChooseDto,UpdateChooseDto>
    {
    }
}
