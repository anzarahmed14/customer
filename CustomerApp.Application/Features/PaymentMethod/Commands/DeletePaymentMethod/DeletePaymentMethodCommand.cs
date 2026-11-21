using MediatR;
using System;

namespace CustomerApp.Application.Features.PaymentMethods.Commands.DeletePaymentMethod
{
    public class DeletePaymentMethodCommand : IRequest<Guid>
    {
        public Guid PaymentId { get; set; }

        public DeletePaymentMethodCommand(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }
}