using FluentValidation;
using InventoryApp.Application.Products.Commands;

namespace InventoryApp.Application.Products.Validators
{
    public class PatchProductCommandValidator : AbstractValidator<PatchProductCommand>
    {
        public PatchProductCommandValidator()
        {
            RuleFor(x => x.Product.Id).NotEmpty();

            // Only validate if the property is not null
            RuleFor(x => x.Product.Name).MaximumLength(100).When(x => x.Product.Name != null);
            RuleFor(x => x.Product.SKU).MaximumLength(50).When(x => x.Product.SKU != null);
            RuleFor(x => x.Product.Category).MaximumLength(50).When(x => x.Product.Category != null);
            RuleFor(x => x.Product.Price).GreaterThan(0).When(x => x.Product.Price.HasValue);
            RuleFor(x => x.Product.StockQuantity).GreaterThanOrEqualTo(0).When(x => x.Product.StockQuantity.HasValue);
        }
    }
}
