using CustomerApp.Application.Features.PaymentMethod.Dto;
using MediatR;
using System;

namespace CustomerApp.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod
{
    public class UpdatePaymentMethodCommand : IRequest<PaymentMethodDto>
    {
        public Guid PaymentId { get; set; }

        public UpdatePaymentMethodCommand(Guid id)
        {
            PaymentId = id;
        }

        public string PaymentMethodName { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}