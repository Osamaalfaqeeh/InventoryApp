using InventoryApp.Application.Interfaces;
using InventoryApp.Application.Products.DTOs;
using MediatR;

namespace InventoryApp.Application.Products.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailsDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDetailsDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }

            return new ProductDetailsDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                SKU = product.SKU,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            };
        }
    }
}
