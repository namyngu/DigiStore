using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonashApp.Context
{
    public class CustomerReviewContext : DbContext
    {
        public DbSet<CustomerReview> CustomerReviews { get; set; }

        public System.Data.Entity.DbSet<MonashApp.Models.Product> Products { get; set; }
    }
}