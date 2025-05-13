namespace InventoryApp.Application.Products.DTOs
{
    /// <summary>
    /// Represents product data returned by the API (GetAll).
    /// </summary>
    public class ProductDto
    {
        /// <summary>Unique product ID.</summary>
        public Guid Id { get; set; }

        /// <summary>Product name.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Product price.</summary>
        public decimal Price { get; set; }
    }
}
