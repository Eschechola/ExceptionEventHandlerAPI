using MediatR;

namespace ExceptionEventHandlerAPI.Data.Notifications
{
    public class DomainEvent : INotification
    {
        public object Message { get; init; }
        public int StatusCode { get; init; }

        public DomainEvent(object message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
