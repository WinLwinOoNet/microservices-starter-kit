using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Msk.Catalog.Api.Entities;
using Msk.Catalog.Api.Repositories;

namespace Msk.Catalog.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            IProductRepository repository,
            ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
            string name,
            string categoryName)
        {
            if(!string.IsNullOrWhiteSpace(name))
                return Ok(await _repository.GetProductsByNameAsync(name));

            if (!string.IsNullOrWhiteSpace(categoryName))
                return Ok(await _repository.GetProductsByCategoryAsync(categoryName));

            return Ok(await _repository.GetProductsAsync());
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _repository.GetProductAsync(id);
            if (product == null)
            {
                _logger.LogError($"Product Id {id} not found.");
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Product>> PostCity([FromBody] Product product)
        {
            await _repository.CreateAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> PutCity(string id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest();

            await _repository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> DeleteCity(string id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
