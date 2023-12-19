using ApiAB202.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ApiAB202.Repositories.Implementations
{
    public class TagRepository : Repository, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {

        }


    }
    
}
