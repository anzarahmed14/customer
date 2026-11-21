using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.OrderDetails.Commands.DeleteOrderDetail
{
    public class DeleteOrderDetailCommandHandler
        : IRequestHandler<DeleteOrderDetailCommand, Guid>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public DeleteOrderDetailCommandHandler(
            IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Guid> Handle(
            DeleteOrderDetailCommand request,
            CancellationToken cancellationToken)
        {
            var orderDetail =
                await _orderDetailRepository.GetByIdAsync(
                    request.OrderId,
                    request.ProductId);

            if (orderDetail == null)
            {
                throw new Exception("Order detail not found.");
            }

            await _orderDetailRepository.DeleteAsync(
                request.OrderId,
                request.ProductId);

            return request.OrderId;
        }
    }
}