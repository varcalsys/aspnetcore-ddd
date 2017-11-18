namespace Dominio.Base.Contratos.Transacoes
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        bool Save();
        void Commit();
        void Rollback();
    }
}
