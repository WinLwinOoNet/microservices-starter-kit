using System.Collections.Generic;
using System.Threading.Tasks;
using Msk.Catalog.Api.Entities;

namespace Msk.Catalog.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(string id);

        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string categoryName);

        Task CreateAsync(Product product);

        Task<bool> UpdateAsync(Product product);

        Task<bool> DeleteAsync(string id);
    }
}
