using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace gunnebo.Data
{
    public static class OrderSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new OrderContext(serviceProvider.GetRequiredService<DbContextOptions<OrderContext>>());
            if (context.Orders.Any())
            {
                return; // DB has been seeded.
            }

            context.Orders.AddRange(
                new Order
                {
                    OrderNumber = 1,
                    OrderRegistrationNumber = 0
                },
                new Order
                {
                    OrderNumber = 2,
                    OrderRegistrationNumber = 1
                }
            );

            context.SaveChanges();
        }
    }
}