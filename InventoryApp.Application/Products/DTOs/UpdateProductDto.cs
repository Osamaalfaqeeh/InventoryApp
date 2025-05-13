namespace InventoryApp.Application.Products.DTOs
{
    /// <summary>
    /// Represents the data required to update an existing product.
    /// </summary>
    public class UpdateProductDto
    {
        /// <summary>Product ID.</summary>
        public Guid Id { get; set; }

        /// <summary>Updated product name.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Updated product description (optional).</summary>
        public string? Description { get; set; } = string.Empty;

        /// <summary>Updated SKU.</summary>
        public string SKU { get; set; } = string.Empty;

        /// <summary>Updated product category.</summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>Updated product price.</summary>
        public decimal Price { get; set; }

        /// <summary>Updated stock quantity.</summary>
        public int StockQuantity { get; set; }
    }
}
