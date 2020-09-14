using System.Collections.Generic;
using System.Threading.Tasks;
using Msk.WebApp.Models;

namespace Msk.WebApp.ApiCollection
{
    public interface ICatalogApi
    {
        Task<IEnumerable<ProductModel>> GetProducts(string name = null, string categoryName = null);

        Task<ProductModel> GetProduct(string id);

        Task<ProductModel> CreateProduct(ProductModel model);
    }
}
