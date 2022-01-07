using Grocery.Entities;
using Grocery.DataAccess.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.DataAccess.Concrete.EFCore
{
    public class GroceryContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-ATM6M2F\SQLEXPRESS;Database=GroceryDb;integrated security=true;");
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            /*modelBuilder.Entity<ProductCategory>()
            .HasOne(p => p.pro)
            .WithMany(d => d.ProductCategories)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);*/

            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });

            base.OnModelCreating(modelBuilder);
       }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CustomerAdress> CustomerAddresses { get; set; }
        public DbSet<CustomerCard> CustomerCards { get; set; }
    }
}
