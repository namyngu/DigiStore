using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonashApp.Context
{
    public class DiscountContext : DbContext
    {
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}