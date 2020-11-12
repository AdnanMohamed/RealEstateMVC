using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Salesperson> Salespeople { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one customer to many properties
            // deleting a customer deletes his/her properties
            //modelBuilder.Entity<Customer>()
            //    .HasMany(p => p.Properties)
            //    .WithOne(c => c.Customer)
            //    .OnDelete(DeleteBehavior.Restrict);

            // one customer to many deals
            // deleting a customer deletes his/ her deals.
            modelBuilder.Entity<Customer>()
                .HasMany(d => d.Deals)
                .WithOne(c => c.Customer)
                .OnDelete(DeleteBehavior.Restrict);

            // one property to one deal
            // deleting the property deletes its associated deal.
            modelBuilder.Entity<Property>()
                .HasMany(p => p.Deals)
                .WithOne(d => d.Property)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Deal>()
                .HasOne(d => d.Customer)
                .WithMany(c => c.Deals)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Deal>()
                .HasOne(d => d.Property)
                .WithMany(p => p.Deals)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
