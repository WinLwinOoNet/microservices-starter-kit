using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Msk.WebApp.ApiCollection.Infrastructure;
using Msk.WebApp.Models;
using Msk.WebApp.Settings;
using Newtonsoft.Json;

namespace Msk.WebApp.ApiCollection
{
    public class CatalogApi : BaseHttpClientWithFactory, ICatalogApi
    {
        private readonly IApiSettings _settings;

        public CatalogApi(IHttpClientFactory factory, IApiSettings settings) : base(factory)
        {
            _settings = settings;
            //factory.CreateClient(base.)
        }

        public async Task<IEnumerable<ProductModel>> GetProducts(string name, string categoryName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.CatalogPath)
                .HttpMethod(HttpMethod.Get)
                .GetHttpMessage();

            return await SendRequest<IEnumerable<ProductModel>>(message);
        }

        public async Task<ProductModel> GetProduct(string id)
        {
            // http://localhost:7000/Products/id
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.CatalogPath)
                .AddToPath(id)
                .HttpMethod(HttpMethod.Get)
                .GetHttpMessage();

            return await SendRequest<ProductModel>(message);
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.CatalogPath)
                .HttpMethod(HttpMethod.Post)
                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<ProductModel>(message);
        }
    }
}
