using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Msk.WebApp.ApiCollection.Infrastructure;
using Msk.WebApp.Models;
using Msk.WebApp.Settings;
using Newtonsoft.Json;

namespace Msk.WebApp.ApiCollection
{
    public class BasketApi : BaseHttpClientWithFactory, IBasketApi
    {
        private readonly IApiSettings _settings;

        public BasketApi(IHttpClientFactory factory, IApiSettings settings) : base(factory)
        {
            _settings = settings;
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.BasketPath)
                .AddToPath(userName)
                .HttpMethod(HttpMethod.Get)
                .GetHttpMessage();

            return await SendRequest<BasketModel>(message);
        }

        public async Task<BasketModel> CreateBasket(BasketModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.BasketPath)
                .HttpMethod(HttpMethod.Post)
                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<BasketModel>(message);
        }

        public async Task CheckoutBasket(BasketCheckoutModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.BasketPath)
                .AddToPath("Checkout")
                .HttpMethod(HttpMethod.Post)
                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            await SendRequest<BasketCheckoutModel>(message);
        }
    }
}
