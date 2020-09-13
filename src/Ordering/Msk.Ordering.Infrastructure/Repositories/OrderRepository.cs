using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Msk.Ordering.Core.Entities;
using Msk.Ordering.Core.Repositories;
using Msk.Ordering.Infrastructure.Data;
using Msk.Ordering.Infrastructure.Repositories.Base;

namespace Msk.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
            => await DbContext.Orders.Where(o => o.UserName == userName).ToListAsync();
    }
}
