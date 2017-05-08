using SharedKernel.DomainEvents.Events;

namespace SharedKernel.DomainEvents.Notifications.EmailNotifications
{
    public class EmailMessage: DomainEvent
    {
        public string From { get; private set; }
        public string[] To { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public EmailMessage(string from, string[] to, string subject, string body)
        {
            From = from;
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
