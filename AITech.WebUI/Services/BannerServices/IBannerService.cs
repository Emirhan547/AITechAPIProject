using AITech.WebUI.DTOs.BannerDtos;
using AITech.WebUI.Services.GenericServices;

namespace AITech.WebUI.Services.BannerServices
{
    public interface IBannerService:IGenericService<ResultBannerDto,CreateBannerDto,UpdateBannerDto>
    {
        Task MakeActiveAsync(int id);
        Task MakePassiveAsync(int id);

    }
}
