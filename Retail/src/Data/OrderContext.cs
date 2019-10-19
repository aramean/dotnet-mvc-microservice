using System;
using Orders.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Orders.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; } // EF Creates table in DB

        // Fluent API, See: https://docs.microsoft.com/en-us/ef/core/modeling/relational/indexes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>()
                        .HasIndex(b => b.OrderNumber)
                        .IsUnique(true)
                        .HasName("Index_OrderNumber");

            modelBuilder.Entity<Order>()
                        .HasIndex(b => b.OrderRegistrationNumber)
                        .HasName("Index_OrderRegistrationNumber");

            modelBuilder.Entity<Order>()
                        .Property(e => e.OrderStatus)
                        .HasConversion(
                            v => v.ToString(),
                            v => (OrderStatusEnum)Enum.Parse(typeof(OrderStatusEnum), v));

            modelBuilder.Entity<Order>()
                        .Property(b => b.OrderDate)
                        .HasDefaultValueSql("getdate()");
        }
    }
}