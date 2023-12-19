using ApiAB202.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ApiAB202.Repositories.Implementations
{
    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

     
    }
    
    
}
