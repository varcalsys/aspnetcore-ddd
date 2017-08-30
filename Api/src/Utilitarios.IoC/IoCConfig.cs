using Infra.Dados.Comuns.Contextos;
using Infra.Dados.Comuns.Transacoes;
using Microsoft.Extensions.DependencyInjection;
using NucleoCompartilhado.DomainEvents.Notifications.DomainNotifications;

namespace Utilitarios.IoC
{
    public class IoCConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<EfContext>(ServiceLifetime.Scoped);
        }
    }
}
