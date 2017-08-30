using System;
using NucleoCompartilhado.DomainEvents.Events;

namespace NucleoCompartilhado.DomainEvents.Interfaces
{
    public interface IHandler<T> : IDisposable where T : DomainEvent
    {
        void Handle(T message);
    }
}
