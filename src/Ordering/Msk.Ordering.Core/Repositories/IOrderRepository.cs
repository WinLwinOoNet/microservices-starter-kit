using System.Collections.Generic;
using System.Threading.Tasks;
using Msk.Ordering.Core.Entities;
using Msk.Ordering.Core.Repositories.Base;

namespace Msk.Ordering.Core.Repositories
{
    public interface  IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
