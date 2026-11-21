using CustomerApp.Application.Features.Order.Queries.GetOrderSummary.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Order.Queries.GetOrderSummary
{
    public class GetOrderSummaryQuery : IRequest<OrderSummaryDto?>
    {
        public Guid OrderId { get; set; }

        public GetOrderSummaryQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
