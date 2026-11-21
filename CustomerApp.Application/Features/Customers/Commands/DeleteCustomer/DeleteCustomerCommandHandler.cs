using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler: IRequestHandler<DeleteCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle( DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }

            await _customerRepository.DeleteAsync(request.Id);

            return request.Id;
        }
    }
}
