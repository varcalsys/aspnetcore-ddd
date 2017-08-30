namespace Infra.Dados.Comuns.Transacoes
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        bool Save();
        void Commit();
        void Rollback();
    }
}
