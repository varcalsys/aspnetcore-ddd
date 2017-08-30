using System.Collections.Generic;
using NucleoCompartilhado.Models.BaseObjects;

namespace Dominio.Base.Contratos
{
    public interface IRepositorioBase<T> where T: Entidade
    {
        IEnumerable<T> SelecionarTodos();
        T ObterPorId(int id);
    }
}
