using CustomerApp.Application.Features.Product.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                return null;
            }

            return new ProductDto
            
            {
                ProductId = product.ProductId,
                ProductName = product.Name,
                ProductPrice = product.Price,
                ProductCode = product.Code,
                IsActive = product.IsActive,

            };
        }
    }
}
