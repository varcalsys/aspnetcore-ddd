using Application.Handlers;
using Infra.Data.Contexts;
using Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.DomainEvents.Interfaces;
using SharedKernel.DomainEvents.Notifications.DomainNotifications;
using SharedKernel.DomainEvents.Notifications.EmailNotifications;

namespace Infra.CrossCutting.IoC
{
    public class IoCConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Application
            services.AddScoped<IHandler<EmailMessage>, EmailMessageHandler>();


            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();


            // Data
            services.AddDbContext<EfContext>();
            
            //Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
