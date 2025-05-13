using FluentValidation;
using InventoryApp.Application.Products.Commands;

namespace InventoryApp.Application.Products.Validators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Product.Id).NotEmpty();
            RuleFor(x => x.Product.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Product.SKU).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Product.Category).NotEmpty();
            RuleFor(x => x.Product.Price).GreaterThan(0);
            RuleFor(x => x.Product.StockQuantity).GreaterThanOrEqualTo(0);
        }
    }
}
