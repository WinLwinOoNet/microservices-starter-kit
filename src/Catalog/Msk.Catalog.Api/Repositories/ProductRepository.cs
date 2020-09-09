using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Msk.Catalog.Api.Data;
using Msk.Catalog.Api.Entities;

namespace Msk.Catalog.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
            => await _context.Products.Find(p => true).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);

            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Category, categoryName);

            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<Product> GetProductAsync(string id)
            => await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Product product)
            => await _context.Products.InsertOneAsync(product);

        public async Task<bool> UpdateAsync(Product product)
        {
            ReplaceOneResult result = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult result = await _context.Products.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
