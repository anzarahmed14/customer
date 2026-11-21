using CustomerApp.Application.Features.Product.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
