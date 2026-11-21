using CustomerApp.Application.Features.Customers.Dto;
using CustomerApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto?>
    {
        public Guid Id { get; set; }
        public GetCustomerByIdQuery(Guid Id) {
            this.Id = Id;
        }

      
    }
}
