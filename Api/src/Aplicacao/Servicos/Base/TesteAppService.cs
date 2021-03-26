using System;
using Dominio.Base.Contratos.Transacoes;
using NucleoCompartilhado.DomainEvents.Events;
using NucleoCompartilhado.DomainEvents.Notifications.DomainNotifications;


namespace Aplicacao.Servicos.Base
{
    public class TesteAppService: AplicacaoServicoBase, ITesteAppService
    {
        public void Salvar()
        {
            DomainEvent.RaiseEvent(new DomainNotification("Teste", "Teste DomainNotification"));
        }

        public TesteAppService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
