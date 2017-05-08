using System;
using SharedKernel.DomainEvents.Events;

namespace SharedKernel.DomainEvents.Interfaces
{
    public interface IHandler<in T>: IDisposable where T: DomainEvent
    {
        void Handle(T message);
    }
}
