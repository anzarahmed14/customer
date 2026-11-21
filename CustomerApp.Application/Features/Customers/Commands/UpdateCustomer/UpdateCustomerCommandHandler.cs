using CustomerApp.Application.Features.Customers.Dto;
using CustomerApp.Application.Interfaces;
using CustomerApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler: IRequestHandler<UpdateCustomerCommand,  CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = request.Id,
                Name = request.Name,
                Address = request.Address,
                City = request.City,
                PostalCode = request.PostalCode,
                Country = request.Country
            };

            await _customerRepository.UpdateAsync(customer);

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                City = customer.City,
                Country = customer.Country
            };
        }
    }
}
