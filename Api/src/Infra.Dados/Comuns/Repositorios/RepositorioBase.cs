using System.Collections.Generic;
using System.Linq;
using Dominio.Base.Contratos;
using Infra.Dados.Comuns.Contextos;
using NucleoCompartilhado.Models.BaseObjects;

namespace Infra.Dados.Comuns.Repositorios
{
    public abstract class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity: Entidade
    {
        private readonly EfContext _efContext;

        protected RepositorioBase(EfContext efContext)
        {
            _efContext = efContext;
        }


        public IEnumerable<TEntity> SelecionarTodos()
        {
            return _efContext.Set<TEntity>().ToList();
        }

        public TEntity ObterPorId(int id)
        {
            return _efContext.Set<TEntity>().FirstOrDefault(x=>x.Id == id);
        }
    }
}
