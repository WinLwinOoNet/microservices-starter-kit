using System.Collections.Generic;
using System.Linq;

namespace Msk.Basket.Api.Entities
{
    public class BasketCart
    {
        public string UserName { get; set; }

        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();

        public BasketCart() {}

        public BasketCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}
