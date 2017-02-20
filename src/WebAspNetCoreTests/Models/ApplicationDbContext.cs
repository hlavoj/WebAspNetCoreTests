using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebAspNetCoreTests.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<BasicPrice> BasicPrices { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerPrice> CustomerPrices { get; set; }

        public DbSet<CustomerProductGroupDiscount> CustomerProductGroupDiscounts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductGroup> ProductGroups { get; set; }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BasicPrice>().HasKey(e => e.BasicPriceId);
            builder.Entity<Customer>().HasKey(e => e.CustomerId);
            builder.Entity<CustomerPrice>().HasKey(e => e.CustomerPriceId);
            builder.Entity<CustomerProductGroupDiscount>().HasKey(e => e.CustomerProductGroupDiscountId);
            builder.Entity<Product>().HasKey(e => e.ProductId);
            builder.Entity<ProductGroup>().HasKey(e => e.ProductGroupId);
        }
    }
}
