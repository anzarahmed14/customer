using CustomerApp.Application.Features.PaymentMethod.Dto;
using MediatR;
using System.Collections.Generic;

namespace CustomerApp.Application.Features.PaymentMethods.Queries.GetAllPaymentMethods
{
    public class GetAllPaymentMethodsQuery
        : IRequest<IEnumerable<PaymentMethodDto>>
    {
    }
}