using CustomerApp.Application.Features.Order.Dto;
using MediatR;
using System.Collections.Generic;

namespace CustomerApp.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
    }
}