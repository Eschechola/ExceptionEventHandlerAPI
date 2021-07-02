using ExceptionEventHandlerAPI.Data.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace ExceptionEventHandlerAPI.Data.Handler
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishDomainEvent<T>(T domainEvent) where T : DomainEvent
        {
            await _mediator.Publish(domainEvent);
        }
    }
}
