using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Msk.Ordering.Core.Entities;

namespace Msk.Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(
            OrderContext orderContext,
            ILoggerFactory loggerFactory,
            int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                orderContext.Database.Migrate();

                if (!await orderContext.Orders.AnyAsync())
                {
                    orderContext.Orders.AddRange(GetPreconfiguredOrders());
                    await orderContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(e.Message);
                    await SeedAsync(orderContext, loggerFactory, retryForAvailability);
                }
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    UserName = "johndoe",
                    TotalPrice= 54,
                    FirstName= "John",
                    LastName= "Doe",
                    EmailAddress= "john@doe.com",
                    AddressLine= "123 Street",
                    Country= "USA",
                    State= "WA",
                    ZipCode= "98101",
                    CardName= "John Doe",
                    CardNumber= "1234-1234-1234-1234",
                    Expiration= "10/2022",
                    CVV= "123",
                    PaymentMethod = PaymentMethod.CreditCard,
                }
            };
        }
    }
}
