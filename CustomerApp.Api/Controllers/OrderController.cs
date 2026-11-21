
using CustomerApp.Application.Features.Order.Queries.GetOrderSummary;
using CustomerApp.Application.Features.Orders.Commands.CreateOrder;
using CustomerApp.Application.Features.Orders.Commands.DeleteOrder;
using CustomerApp.Application.Features.Orders.Commands.UpdateOrder;
using CustomerApp.Application.Features.Orders.Queries.GetAllOrders;
using CustomerApp.Application.Features.Orders.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());

            return Ok(orders);
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));

            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return Ok(order);
        }

        [HttpGet("summary/{id}")]
        public async Task<IActionResult> GetOrderSummary(Guid id)
        {
            var result = await _mediator.Send(
                new GetOrderSummaryQuery(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);

            return Ok(order);
        }

        // PUT: api/Order/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateOrderCommand command)
        {
            if (id != command.OrderId)
            {
                return BadRequest("Order ID does not match.");
            }

            var order = await _mediator.Send(command);

            return Ok(order);
        }

        // DELETE: api/Order/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var order = await _mediator.Send(new DeleteOrderCommand(id));

            return Ok(order);
        }
    }
}