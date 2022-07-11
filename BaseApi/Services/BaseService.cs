using BaseApi.DTOs;
using BaseApi.Entities;
using BaseApi.Repositories;
using BaseApi.Converters;

namespace BaseApi.Services
{
    public class BaseService : IBaseService
    {
        private IBaseRepository _repository;

        public BaseService(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task Inserir(InserirRegistroDto inserir)
        {
            Entity entity;
            var criacao = Converter.ConverterParaTimeStamp(DateTime.Now);

            if (inserir.Id > 0)
                entity = new Entity(inserir.Id, criacao);
            else
                entity = new Entity(criacao);

            await _repository.Inserir(entity);
        }

        public void ValidarRegraDeNegocio()
        {
            throw new ValidationResultException("Informações inválidas");
        }

        public void BuscarRegistro()
        {
            throw new NotFoundException("Registro não encontrado...");
        }
        
    }
}
