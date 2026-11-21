using CustomerApp.Application.Features.PaymentMethod.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.PaymentMethods.Queries.GetAllPaymentMethods
{
    public class GetAllPaymentMethodsQueryHandler
        : IRequestHandler<GetAllPaymentMethodsQuery,
            IEnumerable<PaymentMethodDto>>
    {
        private readonly IPaymentMethodRepository
            _paymentMethodRepository;

        public GetAllPaymentMethodsQueryHandler(
            IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<IEnumerable<PaymentMethodDto>> Handle(
            GetAllPaymentMethodsQuery request,
            CancellationToken cancellationToken)
        {
            var paymentMethods =
                await _paymentMethodRepository.GetAllAsync();

            return paymentMethods.Select(x => new PaymentMethodDto
            {
                PaymentId = x.PaymentId,
                PaymentMethodName = x.PaymentMethodName,
                Code = x.Code,
                IsActive = x.IsActive
            });
        }
    }
}