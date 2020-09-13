using Microsoft.EntityFrameworkCore;
using Msk.Ordering.Core.Entities;

namespace Msk.Ordering.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
