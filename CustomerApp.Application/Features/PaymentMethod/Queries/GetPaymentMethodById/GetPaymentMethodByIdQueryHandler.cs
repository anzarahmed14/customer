using CustomerApp.Application.Features.PaymentMethod.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.PaymentMethods.Queries.GetPaymentMethodById
{
    public class GetPaymentMethodByIdQueryHandler
        : IRequestHandler<GetPaymentMethodByIdQuery, PaymentMethodDto?>
    {
        private readonly IPaymentMethodRepository
            _paymentMethodRepository;

        public GetPaymentMethodByIdQueryHandler(
            IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<PaymentMethodDto?> Handle(
            GetPaymentMethodByIdQuery request,
            CancellationToken cancellationToken)
        {
            var paymentMethod =
                await _paymentMethodRepository
                    .GetByIdAsync(request.PaymentId);

            if (paymentMethod == null)
            {
                return null;
            }

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