using System.Collections.Generic;
using System.Linq;

namespace SharedKernel.DomainEvents.Notifications.DomainNotifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        private IList<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public IList<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(DomainNotification message)
        {
            _notifications.Add(message);
        }

        public bool HasNotification()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
