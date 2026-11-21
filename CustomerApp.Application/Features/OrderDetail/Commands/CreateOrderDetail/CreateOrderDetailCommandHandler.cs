using CustomerApp.Application.Features.OrderDetail.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using OrderDetailEntity = CustomerApp.Domain.Entities.OrderDetail;

namespace CustomerApp.Application.Features.OrderDetails.Commands.CreateOrderDetail
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, OrderDetailDto>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository,
            IProductRepository productRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderDetailDto> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            if (request.Price != product.Price)
            {
                throw new Exception("Order detail price must match product price.");
            }

            var total = request.Quantity * product.Price;

            var orderDetail = new OrderDetailEntity
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Price = product.Price,
                Total = total
            };

            await _orderDetailRepository.AddAsync(orderDetail);

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