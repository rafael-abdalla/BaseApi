using BaseApi.Contexts;
using BaseApi.Entities;

namespace BaseApi.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly BaseAppContext _context;

        public BaseRepository(BaseAppContext context) =>
            _context = context;

        public async Task Inserir(Entity entidade)
        {
            await _context.Entidades.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }
    }
}
