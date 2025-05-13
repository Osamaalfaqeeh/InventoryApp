using InventoryApp.Application.Interfaces;
using InventoryApp.Domain.Entities;
using MediatR;

namespace InventoryApp.Application.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Product.Name,
                Description = request.Product.Description,
                Category = request.Product.Category,
                SKU = request.Product.SKU,
                Price = request.Product.Price,
                StockQuantity = request.Product.StockQuantity

            };

            await _productRepository.AddAsync(newProduct);

            return newProduct.Id;
        }
    }
}
