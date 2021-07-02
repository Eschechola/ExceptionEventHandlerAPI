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

        protected IList<DomainEvent> GetDomainErrors()
            => _domainEventHandler.GetNotifications()
                    .ToList();

        protected bool HasDomainErrors()
            => _domainEventHandler.ErrorsCount() > 0;

        protected ObjectResult GetDomainErrorApiResult()
        {
            var error = GetDomainErrors().FirstOrDefault();
            return StatusCode(error.StatusCode, error.Message);
        }
    }
}
