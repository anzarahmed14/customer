using CustomerApp.Application.Features.Product.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEntity = CustomerApp.Domain.Entities.Product;

namespace CustomerApp.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntity
            {
                ProductId = request.ProductId,
                Name = request.ProductName,
                Price = request.ProductPrice,
                IsActive = request.IsActive,
                Code = request.ProductCode
            };
            await _productRepository.UpdateAsync(product);
            return new ProductDto
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductCode = request.ProductCode,
                IsActive = request.IsActive,
            };
        }
    }
}
