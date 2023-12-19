using System.Linq.Expressions;

namespace ApiAB202.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<IQueryable<Category>> GetAllAsync(Expression<Func<Category, bool>>? expression = null, params string[] includes, int skip, int take);
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task SaveChangesAsync();
    }
}
