using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.UoW
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void Rollback();
        void Commit();
        void Save();
    }
}
