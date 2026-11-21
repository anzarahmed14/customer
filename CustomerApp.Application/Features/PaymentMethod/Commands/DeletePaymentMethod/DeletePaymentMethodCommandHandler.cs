using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.PaymentMethods.Commands.DeletePaymentMethod
{
    public class DeletePaymentMethodCommandHandler
        : IRequestHandler<DeletePaymentMethodCommand, Guid>
    {
        private readonly IPaymentMethodRepository
            _paymentMethodRepository;

        public DeletePaymentMethodCommandHandler(
            IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<Guid> Handle(
            DeletePaymentMethodCommand request,
            CancellationToken cancellationToken)
        {
            var paymentMethod =
                await _paymentMethodRepository
                    .GetByIdAsync(request.PaymentId);

            if (paymentMethod == null)
            {
                throw new Exception(
                    "Payment method not found.");
            }

            await _paymentMethodRepository
                .DeleteAsync(request.PaymentId);

            return request.PaymentId;
        }
    }
}