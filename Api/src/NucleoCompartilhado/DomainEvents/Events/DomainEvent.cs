using System;
using NucleoCompartilhado.DomainEvents.Interfaces;
using NucleoCompartilhado.DomainEvents.Notifications.DomainNotifications;

namespace NucleoCompartilhado.DomainEvents.Events
{
    public abstract class DomainEvent
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }

        public static IServiceProvider ServiceProvider => ContainerAccessor?.Invoke();

        public string EventType { get; protected set; }


        protected DomainEvent()
        {
            EventType = GetType().Name;
        }

        public static void RaiseEvent<T>(T theEvent) where T : Event
        {
            if (ServiceProvider == null) return;

            var obj = ServiceProvider.GetService(theEvent.EventType.Equals(nameof(DomainNotification)) ? typeof(IDomainNotificationHandler) : typeof(IHandler<T>));
            ((IHandler<T>)obj).Handle(theEvent);
        }
    }
}
