using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Order { get; set; }

    }
}
