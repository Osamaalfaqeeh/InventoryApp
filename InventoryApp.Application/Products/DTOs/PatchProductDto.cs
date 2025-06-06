﻿namespace InventoryApp.Application.Products.DTOs;

public class PatchProductDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? SKU { get; set; }

    public string? Category { get; set; }

    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }
}
