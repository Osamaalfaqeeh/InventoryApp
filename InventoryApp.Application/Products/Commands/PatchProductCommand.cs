using InventoryApp.Application.Products.DTOs;
using MediatR;

namespace InventoryApp.Application.Products.Commands;

public record PatchProductCommand(PatchProductDto Product) : IRequest<Unit>;
