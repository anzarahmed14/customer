using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Order.Queries.GetOrderSummary.Dto
{
    public class OrderSummaryDto
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public Guid PaymentId { get; set; }

        public string PaymentName { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public string OrderNo { get; set; } = string.Empty;

        public decimal OrderTotal { get; set; }

        public List<OrderSummaryDetailDto> OrderDetails { get; set; }
            = new List<OrderSummaryDetailDto>();
    }
}
