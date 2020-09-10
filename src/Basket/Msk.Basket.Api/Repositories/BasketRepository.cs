using System.Threading.Tasks;
using Msk.Basket.Api.Data;
using Msk.Basket.Api.Entities;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Msk.Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext _context;

        public BasketRepository(IBasketContext context)
        {
            _context = context;
        }

        public async Task<BasketCart> GetBasket(string userName)
        {
            RedisValue basket = await _context.Redis.StringGetAsync(userName);

            if (basket.IsNullOrEmpty)
                return null;

            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> CreateBasket(BasketCart basket)
        {
            bool result = await _context.Redis.StringSetAsync(
                basket.UserName, JsonConvert.SerializeObject(basket));

            if (!result)
                return null;

            return await GetBasket(basket.UserName);
        }

        public async Task<bool> DeleteBasket(string userName)
            => await _context.Redis.KeyDeleteAsync(userName);
    }
}
