using CustomerApp.Application.Features.PaymentMethod.Dto;
using MediatR;
using System;

namespace CustomerApp.Application.Features.PaymentMethods.Queries.GetPaymentMethodById
{
    public class GetPaymentMethodByIdQuery
        : IRequest<PaymentMethodDto?>
    {
        public Guid PaymentId { get; set; }

        public GetPaymentMethodByIdQuery(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }
}