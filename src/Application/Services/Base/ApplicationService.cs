using Infra.Data.UoW;
using SharedKernel.DomainEvents.Events;
using SharedKernel.DomainEvents.Notifications.DomainNotifications;

namespace Application.Services.Base
{
    public abstract class ApplicationService
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IUnitOfWork _uow;

        protected ApplicationService(IUnitOfWork uow)
        {
            _notifications = (IDomainNotificationHandler<DomainNotification>) DomainEvent.ContainerAccessor().GetService(typeof(IDomainNotificationHandler<DomainNotification>));
            _uow = uow;
        }

        protected void BeginTransaction()
        {
            _uow.BeginTran();
        }

        protected void Commit()
        {
            _uow.Commit();
        }

        protected void Rollback()
        {
            _uow.Rollback();
        }

        protected bool Save()
        {
            if(_notifications.HasNotification()) return false;

            _uow.Save();
            return true;
        }
    }
}
