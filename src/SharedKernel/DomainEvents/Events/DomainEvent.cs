using System;
using SharedKernel.DomainEvents.Interfaces;
using SharedKernel.DomainEvents.Notifications.DomainNotifications;

namespace SharedKernel.DomainEvents.Events
{
    public abstract class DomainEvent
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }

        public static IServiceProvider Container => ContainerAccessor?.Invoke();

        public string EventType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected DomainEvent()
        {
            EventType = GetType().Name;
        }

        public static void RaiseEvent<T>(T theEvent) where T : Event
        {
            if (Container == null) return;
            
            var obj = Container.GetService(theEvent.EventType.Equals("DomainNotification") ? typeof(IDomainNotificationHandler<T>) : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(theEvent);
        }
    }
}
