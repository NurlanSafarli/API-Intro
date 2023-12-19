using ApiAB202.Dtos;


namespace ApiAB202.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<GetCategoryDo>> GetAllAsync(int page, int take);
        Task<GetCategoryDo> GetAsync(int Id);
        Task Create(CreateCategoryDto dto);
        Task UpdateAsync(int id, string name);
        Task DeleteAsync(int id);
    }
}
