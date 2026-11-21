using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DeleteCustomerCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
