using CustomerApp.Application.Features.Product.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto?>
    {
        public Guid ProductId { get; set; }
        public GetProductByIdQuery(Guid ProductId)
        {
           this.ProductId = ProductId; 
        }
    }
}
