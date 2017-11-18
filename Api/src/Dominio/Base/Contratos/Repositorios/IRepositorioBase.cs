using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NucleoCompartilhado.Models.BaseObjects;

namespace Dominio.Base.Contratos
{
    public interface IRepositorioBase<T> where T: Entidade
    {
        IEnumerable<T> SelecionarTodos(params Expression<Func<T, object>>[] includes);
        T ObterPorId(int id, params Expression<Func<T, object>>[] includes);
    }
}
