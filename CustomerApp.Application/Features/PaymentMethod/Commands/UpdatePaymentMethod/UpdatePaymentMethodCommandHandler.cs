using CustomerApp.Application.Features.PaymentMethod.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

using PaymentMethodEntity =
    CustomerApp.Domain.Entities.PaymentMethod;

namespace CustomerApp.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod
{
    public class UpdatePaymentMethodCommandHandler
        : IRequestHandler<UpdatePaymentMethodCommand, PaymentMethodDto>
    {
        private readonly IPaymentMethodRepository
            _paymentMethodRepository;

        public UpdatePaymentMethodCommandHandler(
            IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<PaymentMethodDto> Handle(
            UpdatePaymentMethodCommand request,
            CancellationToken cancellationToken)
        {
            var paymentMethod = new PaymentMethodEntity
            {
                PaymentId = request.PaymentId,
                PaymentMethodName = request.PaymentMethodName,
                Code = request.Code,
                IsActive = request.IsActive
            };

            await _paymentMethodRepository
                .UpdateAsync(paymentMethod);

            return new PaymentMethodDto
            {
                PaymentId = paymentMethod.PaymentId,
                PaymentMethodName = paymentMethod.PaymentMethodName,
                Code = paymentMethod.Code,
                IsActive = paymentMethod.IsActive
            };
        }
    }
}