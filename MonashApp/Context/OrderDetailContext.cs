using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonashApp.Context
{
    public class OrderDetailContext : DbContext
    {
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<MonashApp.Models.Discount> Discounts { get; set; }

        public System.Data.Entity.DbSet<MonashApp.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<MonashApp.Models.Product> Products { get; set; }
    }
}