using BaseApi.DTOs;

namespace BaseApi.Services
{
    public interface IBaseService
    {
        Task Inserir(InserirRegistroDto inserir);

        void ValidarRegraDeNegocio();
        
        void BuscarRegistro();
        
    }
}
