using CustomerApp.Application.Features.OrderDetail.Dto;
using MediatR;
using System;

namespace CustomerApp.Application.Features.OrderDetails.Commands.UpdateOrderDetail
{
    public class UpdateOrderDetailCommand : IRequest<OrderDetailDto>
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }
    }
}