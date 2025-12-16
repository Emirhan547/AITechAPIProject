using AITech.Business.Services.GenericServices;
using AITech.DataAccess.Repositories.FAQRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.DTOs.FAQDtos;
using AITech.Entities.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.IFAQServices
{
    public class FAQService(IFAQRepository _fAQRepository, IUnitOfWork _unitOfWork) : IFAQService
    {
        public async Task TCreateAsync(CreateFAQDto createDto)
        {
            var mappedResult = createDto.Adapt<FAQ>();
            _fAQRepository.CreateAsync(mappedResult);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var faqs=await _fAQRepository.GetByIdAsync(id);
            if (faqs is null)
            {
                throw new Exception(" Soru Cevap Bulunamadı");
            }
            _fAQRepository.Delete(faqs);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultFAQDto>> TGetAllAsync()
        {
            var values=await _fAQRepository.GetAllAsync();
            return values.Adapt<List<ResultFAQDto>>();
        }

        public async Task<ResultFAQDto> TGetByIdAsync(int id)
        {
            var faqs = await _fAQRepository.GetByIdAsync(id);
            if (faqs is null)
            {
                throw new Exception(" Soru Cevap Bulunamadı");
            }
            return faqs.Adapt<ResultFAQDto>();
        }

        public async Task TUpdateAsync(UpdateFAQDto updateDto)
        {
            var mappedResult =updateDto.Adapt<FAQ>();
            _fAQRepository.Update(mappedResult);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
