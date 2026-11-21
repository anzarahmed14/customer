using CustomerApp.Application.Features.Order.Dto;
using MediatR;
using System;

namespace CustomerApp.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<OrderDto>
    {
        public Guid OrderId { get; set; }= Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNo { get; set; } = string.Empty;
        public decimal OrderTotal { get; set; }
    }
}

