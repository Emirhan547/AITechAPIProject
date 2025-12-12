using AITech.DataAccess.Repositories.AboutRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.DTOs.AboutDtos;
using AITech.Entities.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.AboutServices
{
    public class AboutService(IAboutRepository _aboutRepository, IUnitOfWork _unitOfWork) : IAboutService
    {
        public async Task TCreateAsync(CreateAboutDto createDto)
        {
            var mappedResult = createDto.Adapt<About>();
            await _aboutRepository.CreateAsync(mappedResult);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task TDeleteAsync(int id)
        {
            var about=await _aboutRepository.GetByIdAsync(id);
            _aboutRepository.Delete(about);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultAboutDto>> TGetAllAsync()
        {
            var abouts=await _aboutRepository.GetAllAsync();
            return abouts.Adapt<List<ResultAboutDto>>();
        }

        public async Task<ResultAboutDto> TGetByIdAsync(int id)
        {
            var abouts=await _aboutRepository.GetByIdAsync(id);
            return abouts.Adapt<ResultAboutDto>();
        }

        public async Task TUpdateAsync(UpdateAboutDto updateDto)
        {
            var mappedResult=updateDto.Adapt<About>();
            _aboutRepository.Update(mappedResult);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
