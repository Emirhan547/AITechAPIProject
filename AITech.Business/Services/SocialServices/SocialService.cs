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
            var social = await _socialRepository.GetByIdAsync(id);
            if (social is null)
            {
                 new Exception("Social not found");
            }
            _socialRepository.Delete(social);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<List<ResultSocialDto>> TGetAllAsync()
        {
            var values=await _socialRepository.GetAllAsync();
            return values.Adapt<List<ResultSocialDto>>();
        }

        public async Task<ResultSocialDto> TGetByIdAsync(int id)
        {
            var social = await _socialRepository.GetByIdAsync(id);
            if (social is null)
            {
                new Exception("Social not found");
            }
            return social.Adapt<ResultSocialDto>();
        }

        public async Task TUpdateAsync(UpdateSocialDto updateDto)
        {
            var mappedResult=updateDto.Adapt<Social>();
            _socialRepository.Update(mappedResult);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}
