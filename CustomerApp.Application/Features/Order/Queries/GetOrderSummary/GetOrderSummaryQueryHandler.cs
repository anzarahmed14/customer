using CustomerApp.Application.Features.Order.Queries.GetOrderSummary.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Order.Queries.GetOrderSummary
{
    public class GetOrderSummaryQueryHandler: IRequestHandler<GetOrderSummaryQuery, OrderSummaryDto?>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderSummaryQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderSummaryDto?> Handle(GetOrderSummaryQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderSummaryAsync(request.OrderId);

            if (order == null)
            {
                return null;
            }

            return new OrderSummaryDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer.Name,
                PaymentId = order.PaymentId,
                PaymentName = order.PaymentMethod.PaymentMethodName,
                OrderDate = order.OrderDate,
                OrderNo = order.OrderNo,
                OrderTotal = order.OrderTotal,


                OrderDetails = order.OrderDetails
                    .Select(od => new OrderSummaryDetailDto
                    {
                        ProductId = od.ProductId,
                        ProductName = od.Product.Name,
                        Quantity = od.Quantity,

                        Price = od.Price,
                        Total = od.Total
                    }).ToList()
            };
        }
    }
}
