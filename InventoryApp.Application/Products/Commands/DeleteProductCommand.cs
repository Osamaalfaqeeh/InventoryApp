using MediatR;

namespace InventoryApp.Application.Products.Commands;
public record DeleteProductCommand(Guid Id) : IRequest<bool>;
