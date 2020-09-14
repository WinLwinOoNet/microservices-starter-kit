using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Msk.WebApp.Data;
using Msk.WebApp.Entities;
using Msk.WebApp.Repositories.Interfaces;

namespace Msk.WebApp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly MskContext _dbContext;

        public OrderRepository(MskContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Order> CheckOut(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                            .Where(o => o.UserName == userName)
                            .ToListAsync();

            return orderList;
        }
    }
}
