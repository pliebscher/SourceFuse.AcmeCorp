using Microsoft.EntityFrameworkCore;

using AcmeCorp.Data.Models;

namespace AcmeCorp.Data.Context
{
    public class AcmeCorpDataContext : DbContext
    {
        public AcmeCorpDataContext (DbContextOptions<AcmeCorpDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add seed data for testing... The tests would generally do this and then drop the entire test DB when completed.
            modelBuilder.Entity<Customer>().HasData(
              new Customer { Id = 1, Name = "SourceFusion, Inc." },
              new Customer { Id = 2, Name = "Bigfoot Insurance, Inc." }
            );

            modelBuilder.Entity<Contact>().HasData(
              new Contact { Id = 1, CustomerId = 1, FirstName = "Phil", LastName = "Liebscher", Email = "pliebscher@notmail.com" },
              new Contact { Id = 2, CustomerId = 2, FirstName = "Alex", LastName = "Liebscher", Email = "aliebscher@notmail.com" },
              new Contact { Id = 3, CustomerId = 2, FirstName = "Nico", LastName = "Liebscher", Email = "nliebscher@notmail.com" },
              new Contact { Id = 4, CustomerId = 1, FirstName = "Joan", LastName = "Liebscher", Email = "jliebscher@notmail.com" },
              new Contact { Id = 5, CustomerId = 1, FirstName = "Oreo", LastName = "Liebscher", Email = "oliebscher@notmail.com" }
            );

            modelBuilder.Entity<Order>().HasData(
              new Order { Id = 1, ShipToContactId = 1 },
              new Order { Id = 2, ShipToContactId = 2 },
              new Order { Id = 3, ShipToContactId = 5 }
            );

            modelBuilder.Entity<OrderItem>().HasData(
              new OrderItem { Id = 1, OrderId = 1, ProductId = 2 },
              new OrderItem { Id = 2, OrderId = 1, ProductId = 5 },
              new OrderItem { Id = 3, OrderId = 2, ProductId = 4 },
              new OrderItem { Id = 4, OrderId = 3, ProductId = 3 },
              new OrderItem { Id = 5, OrderId = 3, ProductId = 6 }
            );

            modelBuilder.Entity<Product>().HasData(
              new Product { Id = 1, Name = "Toaster", Description = "It makes toast", Price = 25.99 },
              new Product { Id = 2, Name = "Hen Grenade", Description = "Its a hen that explodes", Price = 9.95 },
              new Product { Id = 3, Name = "Rocket-Powered Roller Skates", Description = "Let you skate at unlimited speed", Price = 45.99 },
              new Product { Id = 4, Name = "Giant Kite Kit", Description = "Can be used as a regular kite, or can be used to fly and drop weapons", Price = 99.99 },
              new Product { Id = 5, Name = "Bird Seed", Description = "Part of a bird's nutritious meal", Price = 14.95 },
              new Product { Id = 6, Name = "Nitroglycerin", Description = "HANDLE WITH EXTREME CARE!", Price = 36.75 },
              new Product { Id = 7, Name = "Detonator", Description = "Can be used as an activation to be attached to explosives", Price = 16.95 }
            );
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

    }
}
