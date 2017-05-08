using System;
using SharedKernel.DomainEvents.Interfaces;
using SharedKernel.DomainEvents.Notifications.EmailNotifications;

namespace Application.Handlers
{
    public class EmailMessageHandler : IHandler<EmailMessage>
    {
        public void Handle(EmailMessage message)
        {
            //Send you email here
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
