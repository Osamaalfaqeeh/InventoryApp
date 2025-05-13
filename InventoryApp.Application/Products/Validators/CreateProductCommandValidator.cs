using FluentValidation;
using InventoryApp.Application.Products.Commands;

namespace InventoryApp.Application.Products.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            Console.WriteLine("Validator active");

            RuleFor(x => x.Product.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Product.SKU).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Product.Category).NotEmpty();
            RuleFor(x => x.Product.Price).GreaterThan(0);
            RuleFor(x => x.Product.StockQuantity).GreaterThanOrEqualTo(0);
        }
    }
}
