using System.Collections.Generic;
using System.Threading.Tasks;
using Msk.WebApp.Entities;

namespace Msk.WebApp.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CheckOut(Order order);
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
