using AITech.WebUI.DTOs.FeatureDtos;
using AITech.WebUI.Services.GenericServices;

namespace AITech.WebUI.Services.FeatureServices
{
    public interface IFeatureService:IGenericService<ResultFeatureDto,CreateFeatureDto,UpdateFeatureDto>
    {
    }
}
