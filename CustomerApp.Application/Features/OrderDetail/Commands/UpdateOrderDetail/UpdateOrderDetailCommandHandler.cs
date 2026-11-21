using CustomerApp.Application.Features.OrderDetail.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using OrderDetailEntity = CustomerApp.Domain.Entities.OrderDetail;

namespace CustomerApp.Application.Features.OrderDetails.Commands.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandHandler
        : IRequestHandler<UpdateOrderDetailCommand, OrderDetailDto>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;

        public UpdateOrderDetailCommandHandler(
            IOrderDetailRepository orderDetailRepository,
            IProductRepository productRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderDetailDto> Handle(
            UpdateOrderDetailCommand request,
            CancellationToken cancellationToken)
        {
            var existingOrderDetail =
                await _orderDetailRepository.GetByIdAsync(
                    request.OrderId,
                    request.ProductId);

            if (existingOrderDetail == null)
            {
                throw new Exception("Order detail not found.");
            }

            var product = await _productRepository
                .GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            if (request.Price != product.Price)
            {
                throw new Exception(
                    "Order detail price must match product price.");
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

            await _orderDetailRepository.UpdateAsync(orderDetail);

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