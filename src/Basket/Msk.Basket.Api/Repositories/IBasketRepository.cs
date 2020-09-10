using System.Threading.Tasks;
using Msk.Basket.Api.Entities;

namespace Msk.Basket.Api.Repositories
{
    public interface IBasketRepository
    {
        Task<BasketCart> GetBasket(string userName);

        Task<BasketCart> CreateBasket(BasketCart basket);

        Task<bool> DeleteBasket(string userName);
    }
}