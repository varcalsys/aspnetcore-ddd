using System;

namespace SharedKernel.DomainEvents.Events
{
    public abstract class Event: DomainEvent
    {
        public DateTime DateOccurred { get; protected set; }

        protected Event()
        {
            DateOccurred = DateTime.Now;
        }
    }
}
