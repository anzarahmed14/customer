using CustomerApp.Application.Features.Product.Dto;
using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using ProductEntity = CustomerApp.Domain.Entities.Product;

namespace CustomerApp.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntity
            {
                ProductId = request.ProductId,
                Name = request.ProductName,
                Price = request.ProductPrice,
                Code = request.ProductCode,
                IsActive = request.IsActive
            };

            await _productRepository.AddAsync(product);

            return new ProductDto
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductCode = request.ProductCode,
                IsActive = request.IsActive
            };
        }
    }
}

