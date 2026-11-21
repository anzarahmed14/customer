using CustomerApp.Application.Features.OrderDetail.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.OrderDetails.Queries.GetAllOrderDetails
{
    public class GetAllOrderDetailsQueryHandler
        : IRequestHandler<GetAllOrderDetailsQuery,
            IEnumerable<OrderDetailDto>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public GetAllOrderDetailsQueryHandler(
            IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<IEnumerable<OrderDetailDto>> Handle(
            GetAllOrderDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var orderDetails =
                await _orderDetailRepository.GetAllAsync();

            return orderDetails.Select(x => new OrderDetailDto
            {
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Price = x.Price,
                Total = x.Total
            });
        }
    }
}