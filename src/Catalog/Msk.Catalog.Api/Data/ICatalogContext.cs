using MongoDB.Driver;
using Msk.Catalog.Api.Entities;

namespace Msk.Catalog.Api.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
