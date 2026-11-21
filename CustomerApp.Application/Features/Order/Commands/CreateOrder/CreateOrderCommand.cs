
using CustomerApp.Application.Features.Order.Dto;
using MediatR;

namespace CustomerApp.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderDto>
    {
       // public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNo { get; set; } = string.Empty;
        public decimal OrderTotal { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
    }
}

