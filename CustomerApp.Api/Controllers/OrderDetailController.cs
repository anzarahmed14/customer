using CustomerApp.Application.Features.OrderDetails.Commands.CreateOrderDetail;
using CustomerApp.Application.Features.OrderDetails.Commands.DeleteOrderDetail;
using CustomerApp.Application.Features.OrderDetails.Commands.UpdateOrderDetail;
using CustomerApp.Application.Features.OrderDetails.Queries.GetAllOrderDetails;
using CustomerApp.Application.Features.OrderDetails.Queries.GetOrderDetailById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/OrderDetail
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderDetails =
                await _mediator.Send(new GetAllOrderDetailsQuery());

            return Ok(orderDetails);
        }

        // GET: api/OrderDetail/{orderId}/{productId}
        [HttpGet("{orderId}/{productId}")]
        public async Task<IActionResult> Get(
            Guid orderId,
            Guid productId)
        {
            var orderDetail =
                await _mediator.Send(
                    new GetOrderDetailByIdQuery(
                        orderId,
                        productId));

            if (orderDetail == null)
            {
                return NotFound("Order detail not found.");
            }

            return Ok(orderDetail);
        }

        // POST: api/OrderDetail
        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] CreateOrderDetailCommand command)
        {
            var orderDetail = await _mediator.Send(command);

            return Ok(orderDetail);
        }

        // PUT: api/OrderDetail/{orderId}/{productId}
        [HttpPut("{orderId}/{productId}")]
        public async Task<IActionResult> Put(
            Guid orderId,
            Guid productId,
            [FromBody] UpdateOrderDetailCommand command)
        {
            if (orderId != command.OrderId ||
                productId != command.ProductId)
            {
                return BadRequest(
                    "Order ID or Product ID does not match.");
            }

            var orderDetail =
                await _mediator.Send(command);

            return Ok(orderDetail);
        }

        // DELETE: api/OrderDetail/{orderId}/{productId}
        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> Delete(
            Guid orderId,
            Guid productId)
        {
            var result =
                await _mediator.Send(
                    new DeleteOrderDetailCommand(
                        orderId,
                        productId));

            return Ok(result);
        }
    }
}