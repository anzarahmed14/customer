using CustomerApp.Application.Features.OrderDetail.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Order.Dto
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public Guid PaymentId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNo { get; set; } = string.Empty;

        public decimal OrderTotal { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
    }
}
