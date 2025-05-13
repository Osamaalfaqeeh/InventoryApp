namespace InventoryApp.Application.Products.DTOs
{
    /// <summary>
    /// Represents the data required to create a new product.
    /// </summary>
    public class CreateProductDto
    {
        /// <summary>Product name.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Product description (optional).</summary>
        public string? Description { get; set; } = string.Empty;

        /// <summary>Product category.</summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>Stock Keeping Unit (SKU) identifier.</summary>
        public string SKU { get; set; } = string.Empty;

        /// <summary>Price of the product.</summary>
        public decimal Price { get; set; }

        /// <summary>Available stock quantity.</summary>
        public int StockQuantity { get; set; }
    }
}
