using InventoryApp.Application.Interfaces;
using MediatR;

namespace InventoryApp.Application.Products.Commands
{
    public class PatchProductCommandHandler : IRequestHandler<PatchProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        public PatchProductCommandHandler(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(PatchProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Product;

            var product = await _productRepository.GetByIdAsync(dto.Id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {dto.Id} not found.");

            if (dto.Name != null)
                product.Name = dto.Name;

            if (dto.Description != null)
                product.Description = dto.Description;

            if (dto.SKU != null)
                product.SKU = dto.SKU;

            if (dto.Category != null)
                product.Category = dto.Category;

            if (dto.Price.HasValue)
                product.Price = dto.Price.Value;

            if (dto.StockQuantity.HasValue)
                product.StockQuantity = dto.StockQuantity.Value;

            product.UpdatedAt = DateTime.UtcNow;

            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
