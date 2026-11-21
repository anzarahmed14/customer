using CustomerApp.Application.Features.PaymentMethods.Commands.CreatePaymentMethod;
using CustomerApp.Application.Features.PaymentMethods.Commands.DeletePaymentMethod;
using CustomerApp.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod;
using CustomerApp.Application.Features.PaymentMethods.Queries.GetAllPaymentMethods;
using CustomerApp.Application.Features.PaymentMethods.Queries.GetPaymentMethodById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentMethodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/PaymentMethod
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var paymentMethods =
                await _mediator.Send(
                    new GetAllPaymentMethodsQuery());

            return Ok(paymentMethods);
        }

        // GET: api/PaymentMethod/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var paymentMethod =
                await _mediator.Send(
                    new GetPaymentMethodByIdQuery(id));

            if (paymentMethod == null)
            {
                return NotFound("Payment method not found.");
            }

            return Ok(paymentMethod);
        }

        // POST: api/PaymentMethod
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentMethodCommand command)
        {
            var paymentMethod =
                await _mediator.Send(command);

            return Ok(paymentMethod);
        }

        // PUT: api/PaymentMethod/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(
            Guid id,
            [FromBody] UpdatePaymentMethodCommand command)
        {
            if (id != command.PaymentId)
            {
                return BadRequest(
                    "Payment ID does not match.");
            }

            var paymentMethod =
                await _mediator.Send(command);

            return Ok(paymentMethod);
        }

        // DELETE: api/PaymentMethod/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var paymentMethod =
                await _mediator.Send(
                    new DeletePaymentMethodCommand(id));

            return Ok(paymentMethod);
        }
    }
}