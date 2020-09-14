using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Msk.WebApp.Entities;

namespace Msk.WebApp.Data
{
    public class MskContext : DbContext
    {
        public MskContext(DbContextOptions<MskContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        /*public async Task SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }*/
    }
}
