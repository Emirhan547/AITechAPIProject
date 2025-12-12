using AITech.DataAccess.Repositories.TestimonialRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.DTOs.TestimonialDtos;
using AITech.Entities.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.TestimonialServices
{
    public class TestimonialService(ITestimonialRepository _testimonialRepository, IUnitOfWork _unitOfWork) : ITestimonialService
    {
        public async Task TCreateAsync(CreateTestimonialDto createDto)
        {
            var mappedResult = createDto.Adapt<Testimonial>();
            await _testimonialRepository.CreateAsync(mappedResult);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var values=await _testimonialRepository.GetByIdAsync(id);
             _testimonialRepository.Delete(values);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultTestimonialDto>> TGetAllAsync()
        {
            var values = await _testimonialRepository.GetAllAsync();
            return values.Adapt<List<ResultTestimonialDto>>();
        }

        public async Task<ResultTestimonialDto> TGetByIdAsync(int id)
        {
            var values = await _testimonialRepository.GetByIdAsync(id);
            return values.Adapt<ResultTestimonialDto>();
        }

        public async Task TUpdateAsync(UpdateTestimonialDto updateDto)
        {
            var mappedResult=updateDto.Adapt<Testimonial>();
            _testimonialRepository.Update(mappedResult);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
