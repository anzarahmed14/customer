using CustomerApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            await _productRepository.DeleteAsync(request.ProductId);

            return request.ProductId;
        }
    }
}

