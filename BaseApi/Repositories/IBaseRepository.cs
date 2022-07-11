using BaseApi.Entities;

namespace BaseApi.Repositories
{
    public interface IBaseRepository
    {
        Task Inserir(Entity entidade);
    }
}
