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

            // Add seed data
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
