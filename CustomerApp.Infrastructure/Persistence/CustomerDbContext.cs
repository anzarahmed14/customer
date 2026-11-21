using CustomerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Infrastructure.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext( DbContextOptions<CustomerDbContext> options): base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetail { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            // Product Price
            modelBuilder.Entity<Product>() 
                .Property(x => x.Price) 
                .HasPrecision(18, 2); 
            // Order Total
            modelBuilder.Entity<Order>()
                .Property(x => x.OrderTotal)
                .HasPrecision(18, 2); 
            // OrderDetail Price
            modelBuilder.Entity<OrderDetail>() 
                .Property(x => x.Price) 
                .HasPrecision(18, 2); 
            // OrderDetail Total
             modelBuilder.Entity<OrderDetail>()
                .Property(x => x.Total)
                .HasPrecision(18, 2); }
        }
}
