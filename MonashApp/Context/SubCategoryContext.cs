using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonashApp.Context
{
    public class SubCategoryContext : DbContext
    {
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<MonashApp.Models.MainCategory> MainCategories { get; set; }
    }
}