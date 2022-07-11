using BaseApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Contexts
{
    public class BaseAppContext : DbContext
    {
        public BaseAppContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Entity> Entidades { get; set; }
    }
}
