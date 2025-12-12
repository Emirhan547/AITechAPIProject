using AITech.DataAccess.Repositories.ChooseRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.DTOs.ChooseDtos;
using AITech.Entities.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.ChooseServices
{
    public class ChooseService(IChooseRepository _chooseRepository, IUnitOfWork _unitOfWork) : IChooseService
    {
        public async Task TCreateAsync(CreateChooseDto createDto)
        {
            var mappedResult = createDto.Adapt<Choose>();
            await _chooseRepository.CreateAsync(mappedResult);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
           var values=await _chooseRepository.GetByIdAsync(id);
            _chooseRepository.Delete(values);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultChooseDto>> TGetAllAsync()
        {
            var values=await _chooseRepository.GetAllAsync();
            return values.Adapt<List<ResultChooseDto>>();
        }

        public async Task<ResultChooseDto> TGetByIdAsync(int id)
        {
            var values=await _chooseRepository.GetByIdAsync(id);
            return values.Adapt<ResultChooseDto>();
        }

        public async Task TUpdateAsync(UpdateChooseDto updateDto)
        {
            var values= updateDto.Adapt<Choose>();
            _chooseRepository.Update(values);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
