using CustomerApp.Application.Features.Order.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using OrderEntity = CustomerApp.Domain.Entities.Order;

namespace CustomerApp.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new OrderEntity
            {
                OrderId = request.OrderId,
                CustomerId = request.CustomerId,
                PaymentId = request.PaymentId,
                OrderDate = request.OrderDate,
                OrderNo = request.OrderNo,
                OrderTotal = request.OrderTotal
            };

            await _orderRepository.UpdateAsync(order);

            return new OrderDto
            {
                OrderId = request.OrderId,
                CustomerId = request.CustomerId,
                PaymentId = request.PaymentId,
                OrderDate = request.OrderDate,
                OrderNo = request.OrderNo,
                OrderTotal = request.OrderTotal,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDto
                {
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    Price = od.Price,
                    
                }).ToList()
            };
        }
    }
}

