using InventoryApp.Application.Interfaces;
using MediatR;

namespace InventoryApp.Application.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Product;

            var product = await _productRepository.GetByIdAsync(dto.Id);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {dto.Id} not found.");

            // Update values
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Category = dto.Category;
            product.SKU = dto.SKU;
            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;
            product.UpdatedAt = DateTime.UtcNow;

            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
