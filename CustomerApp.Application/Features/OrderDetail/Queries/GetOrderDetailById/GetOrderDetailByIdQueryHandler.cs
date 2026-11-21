using CustomerApp.Application.Features.OrderDetail.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.OrderDetails.Queries.GetOrderDetailById
{
    public class GetOrderDetailByIdQueryHandler
        : IRequestHandler<GetOrderDetailByIdQuery, OrderDetailDto?>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public GetOrderDetailByIdQueryHandler(
            IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetailDto?> Handle(
            GetOrderDetailByIdQuery request,
            CancellationToken cancellationToken)
        {
            var orderDetail =
                await _orderDetailRepository.GetByIdAsync(
                    request.OrderId,
                    request.ProductId);

            if (orderDetail == null)
            {
                return null;
            }

            return new OrderDetailDto
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price,
                Total = orderDetail.Total
            };
        }
    }
}