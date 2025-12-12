using AITech.DataAccess.Repositories.SocialRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.DTOs.SocialDtos;
using AITech.Entities.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.SocialServices
{
    public class SocialService(ISocialRepository _socialRepository, IUnitOfWork _unitOfWork) : ISocialService
    {
        public async Task TCreateAsync(CreateSocialDto createDto)
        {
            var mappedResult = createDto.Adapt<Social>();
            await _socialRepository.CreateAsync(mappedResult);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var values = await _socialRepository.GetByIdAsync(id);
             _socialRepository.Delete(values);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<List<ResultSocialDto>> TGetAllAsync()
        {
            var values=await _socialRepository.GetAllAsync();
            return values.Adapt<List<ResultSocialDto>>();
        }

        public async Task<ResultSocialDto> TGetByIdAsync(int id)
        {
            var values=await _socialRepository.GetByIdAsync(id);
            return values.Adapt<ResultSocialDto>();
        }

        public async Task TUpdateAsync(UpdateSocialDto updateDto)
        {
            var mappedResult=updateDto.Adapt<Social>();
            _socialRepository.Update(mappedResult);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}
