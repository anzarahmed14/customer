using CustomerApp.Application.Features.PaymentMethod.Dto;
using MediatR;
using System;

namespace CustomerApp.Application.Features.PaymentMethods.Commands.CreatePaymentMethod
{
    public class CreatePaymentMethodCommand : IRequest<PaymentMethodDto>
    {
        public Guid PaymentId { get; set; } = Guid.NewGuid();
        public string PaymentMethodName { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}