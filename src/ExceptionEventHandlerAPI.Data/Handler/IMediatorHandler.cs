using ExceptionEventHandlerAPI.Data.Notifications;
using System.Threading.Tasks;

namespace ExceptionEventHandlerAPI.Data.Handler
{
    public interface IMediatorHandler
    {
        Task PublishDomainEvent<T>(T domainEvent) where T : DomainEvent;
    }
}
