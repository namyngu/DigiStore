using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MonashApp.Models
{
    public partial class DigiStoreModels : DbContext
    {
        public DigiStoreModels()
            : base("name=DigiStoreModels")
        {
        }

        public virtual DbSet<AspNetUsers_Admin> AspNetUsers_Admin { get; set; }
        public virtual DbSet<AspNetUsers_Customer> AspNetUsers_Customer { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<CustomerReview> CustomerReviews { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<MainCategory> MainCategories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Staff)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Tier1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Tier2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Tier3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MainCategory>()
                .HasMany(e => e.SubCategories)
                .WithRequired(e => e.MainCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ListPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.BasePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CustomerReviews)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.SubCategory)
                .WillCascadeOnDelete(false);
        }
    }
}
