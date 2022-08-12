using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonashApp.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<CustomerReview> CustomerReviews { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<MonashApp.Models.Brand> Brands { get; set; }

        public System.Data.Entity.DbSet<MonashApp.Models.SubCategory> SubCategories { get; set; }
    }
}