using ExceptionEventHandlerAPI.Data.Enums;
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

        protected IList<DomainEvent> GetDomainEvents()
            => _domainEventHandler.GetNotifications()
                    .ToList();

        protected bool HasDomainErrors()
            => _domainEventHandler.ErrorsCount() > 0;

        protected ObjectResult ApiResult()
        {
            var domainEvent = GetDomainEvents()
                .FirstOrDefault();

            return StatusCode(GetStatusCodeByErrorType(domainEvent.Error), domainEvent.Message);
        }

        private int GetStatusCodeByErrorType(ErrorType errorType)
        {
            switch (errorType)
            {
                case ErrorType.BadRequest:
                    return 400;
            }

            return 500;
        }
    }
}
