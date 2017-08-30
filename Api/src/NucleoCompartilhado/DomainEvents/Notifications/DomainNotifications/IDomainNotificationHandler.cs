using System.Collections.Generic;
using NucleoCompartilhado.DomainEvents.Interfaces;

namespace NucleoCompartilhado.DomainEvents.Notifications.DomainNotifications
{
    public interface IDomainNotificationHandler: IHandler<DomainNotification>
    {
        bool HasNotification();
        IList<DomainNotification> GetNotifications();
    }
}
