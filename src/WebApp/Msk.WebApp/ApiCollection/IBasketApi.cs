using System.Threading.Tasks;
using Msk.WebApp.Models;

namespace Msk.WebApp.ApiCollection
{
    public interface IBasketApi
    {
        Task<BasketModel> GetBasket(string userName);

        Task<BasketModel> CreateBasket(BasketModel model);

        Task CheckoutBasket(BasketCheckoutModel model);
    }
}
