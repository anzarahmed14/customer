using CustomerApp.Application.Features.OrderDetail.Dto;
using MediatR;
using System.Collections.Generic;

namespace CustomerApp.Application.Features.OrderDetails.Queries.GetAllOrderDetails
{
    public class GetAllOrderDetailsQuery
        : IRequest<IEnumerable<OrderDetailDto>>
    {
    }
}