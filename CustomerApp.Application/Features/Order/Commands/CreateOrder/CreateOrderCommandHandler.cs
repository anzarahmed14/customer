using CustomerApp.Application.Features.Order.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using OrderEntity = CustomerApp.Domain.Entities.Order;

namespace CustomerApp.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new OrderEntity
            {
                OrderId = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                PaymentId = request.PaymentId,
                OrderDate = request.OrderDate,
                OrderNo = request.OrderNo,
                OrderTotal = request.OrderTotal
            };


            foreach (var item in request.OrderDetails)
            {
                //var product = await _productRepository.GetByIdAsync(item.ProductId);

                //if (product == null)
                //    throw new Exception($"Product not found: {item.ProductId}");

                order.OrderDetails.Add(new Domain.Entities.OrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Total = item.Price * item.Quantity
                });
            }


            //order.OrderDetails.Add(new Domain.Entities.OrderDetail()
            //{
            //    ProductId = Guid.Parse("B16D99B7-4375-45B4-ADE4-08DF07EFFFFC"),
            //    Quantity = 1,
            //    Price = 25000,
            //    Total = 25000

            //});
            //order.OrderDetails.Add(new Domain.Entities.OrderDetail()
            //{
            //    ProductId = Guid.Parse("E546A097-1994-4C67-80EC-08DF080E543E"),
            //    Quantity = 1,
            //    Price = 25000,
            //    Total = 25000

            //});
            //order.OrderDetails.Add(new Domain.Entities.OrderDetail()
            //{
            //    ProductId = Guid.Parse("AB9B123A-34E6-4362-80ED-08DF080E543E"),
            //    Quantity = 1,
            //    Price = 25000,
            //    Total = 25000

            //});


          var Order = await _orderRepository.AddAsync(order);

            return new OrderDto
            {
                OrderId = Order.OrderId,
                CustomerId = request.CustomerId,
                PaymentId = request.PaymentId,
                OrderDate = request.OrderDate,
                OrderNo = request.OrderNo,
                OrderTotal = request.OrderTotal,
                OrderDetails = request.OrderDetails
            };
        }
    }
}

