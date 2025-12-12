using AITech.DataAccess.Repositories.FeatureRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.DTOs.FeatureDtos;
using AITech.Entities.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.FeatureServices
{
    public class FeatureService(IFeatureRepository _featureRepository, IUnitOfWork _unitOfWork) : IFeatureService
    {
        public async Task TCreateAsync(CreateFeatureDto createDto)
        {
            var mappedResult = createDto.Adapt<Feature>();
            await _featureRepository.CreateAsync(mappedResult);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var values=await _featureRepository.GetByIdAsync(id);
            _featureRepository.Delete(values);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultFeatureDto>> TGetAllAsync()
        {
            var values=await _featureRepository.GetAllAsync();
            return values.Adapt<List<ResultFeatureDto>>();
        }

        public async Task<ResultFeatureDto> TGetByIdAsync(int id)
        {
            var values=await _featureRepository.GetByIdAsync(id);
            return values.Adapt<ResultFeatureDto>();
        }

        public async Task TUpdateAsync(UpdateFeatureDto updateDto)
        {
            var mappedResult=updateDto.Adapt<Feature>();
            _featureRepository.Update(mappedResult);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
