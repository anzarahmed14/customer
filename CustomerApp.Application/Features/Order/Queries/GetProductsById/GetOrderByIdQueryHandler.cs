using CustomerApp.Application.Features.Order.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto?> Handle(
            GetOrderByIdQuery request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository
               .GetByIdAsync(request.OrderId);

            if (order == null)
            {
                return null;
            }

            return new OrderDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                PaymentId = order.PaymentId,
                OrderDate = order.OrderDate,
                OrderNo = order.OrderNo,
                OrderTotal = order.OrderTotal,

                OrderDetails = order.OrderDetails
                    .Select(od => new OrderDetailDto
                    {
                        ProductId = od.ProductId,
                        Quantity = od.Quantity,
                        Price = od.Price
                    })
                    .ToList()
            };
        }
    }
}