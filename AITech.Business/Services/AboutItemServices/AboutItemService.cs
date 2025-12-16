using AITech.DataAccess.Repositories.AboutItemRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.DTOs.AboutItemDtos;
using AITech.Entities.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.AboutItemServices
{
    public class AboutItemService(IAboutItemRepository _aboutItemRepository, IUnitOfWork _unitOfWork) : IAboutItemService
    {
        public async Task TCreateAsync(CreateAboutItemDto createDto)
        {
            var mappedResult = createDto.Adapt<AboutItem>();
            await _aboutItemRepository.CreateAsync(mappedResult);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var aboutItem=await _aboutItemRepository.GetByIdAsync(id);
            if (aboutItem is null)
            {
                throw new Exception(" Hakkında Bulunamadı");
            }
            _aboutItemRepository.Delete(aboutItem);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultAboutItemDto>> TGetAllAsync()
        {
            var values=await _aboutItemRepository.GetAllAsync();
            return values.Adapt<List<ResultAboutItemDto>>();
        }

        public async Task<ResultAboutItemDto> TGetByIdAsync(int id)
        {
            var aboutItem = await _aboutItemRepository.GetByIdAsync(id);
            if (aboutItem is null)
            {
                throw new Exception(" Hakkında Bulunamadı");
            }
            return aboutItem.Adapt<ResultAboutItemDto>();
        }

        public async Task TUpdateAsync(UpdateAboutItemDto updateDto)
        {
            var values=updateDto.Adapt<AboutItem>();
            _aboutItemRepository.Update(values);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
