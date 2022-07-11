namespace BaseApi.Entities
{
    public class Entity
    {
        public Entity(DateTime criacao)
        {
            Criacao = criacao;
        }

        public Entity(int id, DateTime criacao)
        {
            Id = id;
            Criacao = criacao;
        }

        public int Id { get; private set; }
        public DateTime Criacao { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }
    }
}
