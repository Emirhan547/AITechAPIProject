using AITech.WebUI.DTOs.AboutDtos;
using AITech.WebUI.Services.GenericServices;

namespace AITech.WebUI.Services.AboutServices
{
    public interface IAboutService:IGenericService<ResultAboutDto,CreateAboutDto,UpdateAboutDto>
    {
    }
}
