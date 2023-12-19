namespace ApiAB202.Repositories.Interfaces
{
    public interface ITagRepository : IRepository
    {
        Task AddAsync(Tag tag);
    }
}
