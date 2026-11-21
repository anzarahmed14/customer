using CustomerApp.Application.Features.OrderDetail.Dto;
using MediatR;
using System;

namespace CustomerApp.Application.Features.OrderDetails.Queries.GetOrderDetailById
{
    public class GetOrderDetailByIdQuery
        : IRequest<OrderDetailDto?>
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public GetOrderDetailByIdQuery(
            Guid orderId,
            Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}