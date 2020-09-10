using StackExchange.Redis;

namespace Msk.Basket.Api.Data
{
    public interface IBasketContext
    {
        IDatabase Redis { get; }
    }
}
