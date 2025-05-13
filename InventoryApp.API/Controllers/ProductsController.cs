using InventoryApp.Application.Products.Commands;
using InventoryApp.Application.Products.DTOs;
using InventoryApp.Application.Products.Queries;
using InventoryApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.API.Controllers
{
    /// <summary>
    /// Controller for managing products
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the ProductsController class.
        /// </summary>
        /// <param name="mediator">MediatR instance for handling requests.</param>
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieve all Products
        /// </summary>
        /// <returns>A list of products</returns>
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        /// <summary>
        /// Retrieve specific product by ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>The requested product if found.</returns>
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return result == null ? NotFound() : Ok(result);
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="product">The updated product data.</param>
        /// <returns>No content if successful; otherwise, a bad request.</returns>
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, UpdateProductDto product)
        {
            if (id != product.Id)
            {
                return BadRequest("ID in URL does not match DTO");
            }

            await _mediator.Send(new UpdateProductCommand(product));

            return NoContent();
        }

        /// <summary>
        /// Partially updates a product.
        /// </summary>
        /// <param name="id">The ID of the product to patch.</param>
        /// <param name="product">The patch data.</param>
        /// <returns>No content if successful; otherwise, a bad request.</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProduct(Guid id, PatchProductDto product)
        {
            if (id != product.Id)
                return BadRequest("ID mismatch");

            await _mediator.Send(new PatchProductCommand(product));
            return NoContent();
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>The ID of the created product.</returns>
        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] CreateProductDto product)
        {
            var Id = await _mediator.Send(new CreateProductCommand(product));

            return CreatedAtAction(nameof(GetProduct), new { id = Id }, Id);
        }

        /// <summary>
        /// Deletes a product by ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>OK if successful; NotFound if the product does not exist.</returns>
        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var success = await _mediator.Send(new DeleteProductCommand(id));
            return success ? Ok(success) : NotFound();
        }
    }
}
