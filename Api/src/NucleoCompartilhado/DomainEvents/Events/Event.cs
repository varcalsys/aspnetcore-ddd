﻿using System;

namespace NucleoCompartilhado.DomainEvents.Events
{
    public abstract class Event : DomainEvent
    {
        public DateTime DateOccurred { get; protected set; }

        protected Event()
        {
            DateOccurred = DateTime.Now;
        }
    }
}
