using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler
        : IRequestHandler<DeleteOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(
            DeleteOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository
                .GetByIdAsync(request.OrderId);

            if (order == null)
            {
                throw new Exception("Order not found.");
            }

            await _orderRepository
                .DeleteAsync(request.OrderId);

            return request.OrderId;
        }
    }
}