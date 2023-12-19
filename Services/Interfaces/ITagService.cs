
using ApiAB202.Dtos;


namespace ApiAB202.Services.Interfaces
{
    public interface ITagService

    {
        Task<ICollection<GetTagDto>> GetAllAsync(int page, int take);
        Task<GetTagDto> GetAsync(int Id);
        Task Create(CreateTagDto dto);
        Task UpdateAsync(int id, string name);
        Task DeleteAsync(int id);
    }
}
