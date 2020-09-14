using System.Collections.Generic;
using System.Threading.Tasks;
using Msk.WebApp.Models;

namespace Msk.WebApp.ApiCollection
{
    public interface IOrderApi
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
