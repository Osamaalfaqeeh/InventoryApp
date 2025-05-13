using InventoryApp.Application.Products.DTOs;
using MediatR;

namespace InventoryApp.Application.Products.Queries;
public record GetProductByIdQuery(Guid Id) : IRequest<ProductDetailsDto>;
