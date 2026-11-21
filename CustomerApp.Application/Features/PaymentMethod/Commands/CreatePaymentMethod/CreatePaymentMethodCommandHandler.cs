using CustomerApp.Application.Features.PaymentMethod.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using PaymentMethodEntity =
    CustomerApp.Domain.Entities.PaymentMethod;

namespace CustomerApp.Application.Features.PaymentMethods.Commands.CreatePaymentMethod
{
    public class CreatePaymentMethodCommandHandler
        : IRequestHandler<CreatePaymentMethodCommand, PaymentMethodDto>
    {
        private readonly IPaymentMethodRepository
            _paymentMethodRepository;

        public CreatePaymentMethodCommandHandler(
            IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<PaymentMethodDto> Handle(
            CreatePaymentMethodCommand request,
            CancellationToken cancellationToken)
        {
            var paymentMethod = new PaymentMethodEntity
            {
                PaymentId = request.PaymentId,
                PaymentMethodName = request.PaymentMethodName,
                Code = request.Code,
                IsActive = request.IsActive
            };

            await _paymentMethodRepository.AddAsync(paymentMethod);

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