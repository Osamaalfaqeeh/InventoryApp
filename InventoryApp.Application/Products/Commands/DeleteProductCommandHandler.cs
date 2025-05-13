using InventoryApp.Application.Interfaces;
using InventoryApp.Domain.Entities;
using MediatR;

namespace InventoryApp.Application.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return false;
            }

            await _productRepository.DeleteAsync(request.Id);

            return true;
        }
    }
}
