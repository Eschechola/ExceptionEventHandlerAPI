using ExceptionEventHandlerAPI.Data.Notifications;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ExceptionEventHandlerAPI.Data.Handler
{
    public class DomainEventHandler : INotificationHandler<DomainEvent>
    {
        private IList<DomainEvent> _notifications;

        public DomainEventHandler()
        {
            _notifications = new List<DomainEvent>();
        }

        public Task Handle(DomainEvent notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public IList<DomainEvent> GetNotifications()
            => _notifications;

        public int ErrorsCount()
            => _notifications.Count;
    }
}
