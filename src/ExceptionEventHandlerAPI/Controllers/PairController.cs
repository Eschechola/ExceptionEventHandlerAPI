using ExceptionEventHandlerAPI.Data.Enums;
using ExceptionEventHandlerAPI.Data.Handler;
using ExceptionEventHandlerAPI.Data.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExceptionEventHandlerAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PairController : BaseController
    {
        private readonly IMediatorHandler _mediator;

        public PairController(
            IMediatorHandler mediator,
            INotificationHandler<DomainEvent> notifications) : base(notifications)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("is-pair/{number}")]
        public async Task<IActionResult> IsPair(int number)
        {
            if (number % 2 == 0)
                return Ok(true);

            await _mediator.PublishDomainEvent(new DomainEvent(false, ErrorType.BadRequest));

            return ApiResult();
        }
    }
}
