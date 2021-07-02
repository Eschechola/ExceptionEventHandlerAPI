using ExceptionEventHandlerAPI.Data.Enums;
using MediatR;

namespace ExceptionEventHandlerAPI.Data.Notifications
{
    public class DomainEvent : INotification
    {
        public object Message { get; init; }
        public ErrorType Error { get; init; }

        public DomainEvent(object message, ErrorType error)
        {
            Message = message;
            Error = error;
        }
    }
}
