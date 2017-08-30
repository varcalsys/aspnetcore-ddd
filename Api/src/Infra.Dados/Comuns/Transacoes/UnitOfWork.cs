using Infra.Dados.Comuns.Contextos;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Dados.Comuns.Transacoes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfContext _efContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EfContext efContext)
        {
            _efContext = efContext;
        }

        public void BeginTransaction()
        {
            _transaction = _efContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public bool Save()
        {
           return _efContext.SaveChanges() > 0;
        }
    }
}
