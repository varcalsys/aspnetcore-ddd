using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Data.UoW
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly EfContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EfContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SaveAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
