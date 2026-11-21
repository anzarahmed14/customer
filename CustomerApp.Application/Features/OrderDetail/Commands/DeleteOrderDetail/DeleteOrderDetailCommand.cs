using MediatR;
using System;

namespace CustomerApp.Application.Features.OrderDetails.Commands.DeleteOrderDetail
{
    public class DeleteOrderDetailCommand : IRequest<Guid>
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public DeleteOrderDetailCommand(
            Guid orderId,
            Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}