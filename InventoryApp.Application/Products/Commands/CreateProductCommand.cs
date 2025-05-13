using InventoryApp.Application.Products.DTOs;
using MediatR;

namespace InventoryApp.Application.Products.Commands;
public record CreateProductCommand(CreateProductDto Product) : IRequest<Guid>;
