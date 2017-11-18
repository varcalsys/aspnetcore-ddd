using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.Base.Contratos;
using Infra.Dados.Comuns.Contextos;
using Infra.Dados.Extensoes;
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

        public IEnumerable<TEntity> SelecionarTodos(params Expression<Func<TEntity, object>>[] includes)
        {
            return _efContext.Set<TEntity>()
                .IncludeMultiple()
                .ToList();
        }

        public TEntity ObterPorId(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            return _efContext.Set<TEntity>()
                .IncludeMultiple(includes)
                .FirstOrDefault(x=>x.Id == id);
        }
    }
}
