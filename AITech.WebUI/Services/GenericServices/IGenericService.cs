using AITech.WebUI.DTOs.CategoryDtos;

namespace AITech.WebUI.Services.GenericServices
{
    public interface IGenericService<TResult,TCreate,TUpdate>
    {
        Task<List<TResult>> GetAllAsync();
        Task<TUpdate> GetByIdAsync(int id);
        Task CreateAsync(TCreate create);
        Task UpdateAsync(TUpdate update);
        Task DeleteAsync(int id);
    }
}
