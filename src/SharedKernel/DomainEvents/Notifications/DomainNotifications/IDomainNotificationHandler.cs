using System.Collections.Generic;
using SharedKernel.DomainEvents.Events;
using SharedKernel.DomainEvents.Interfaces;

namespace SharedKernel.DomainEvents.Notifications.DomainNotifications
{
    public interface IDomainNotificationHandler<T>: IHandler<T> where T: DomainEvent
    {
        bool HasNotification();
        IList<T> GetNotifications();
    }
}
