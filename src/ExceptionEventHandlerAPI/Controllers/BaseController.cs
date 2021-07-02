using ExceptionEventHandlerAPI.Data.Handler;
using ExceptionEventHandlerAPI.Data.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionEventHandlerAPI.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainEventHandler _domainEventHandler;

        protected BaseController(INotificationHandler<DomainEvent> domainEventHandler)
        {
            _domainEventHandler = (DomainEventHandler)domainEventHandler;
        }

        protected DomainEvent GetDomainError()
            => _domainEventHandler.GetNotifications()
                    .FirstOrDefault();
    }
}
