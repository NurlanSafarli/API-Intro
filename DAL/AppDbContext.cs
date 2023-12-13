using ApiAB202.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiAB202.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options )
            :base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
