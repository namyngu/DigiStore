using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonashApp.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public Brand Brand { get; set; }
        public SubCategory SubCategory { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
    }

    
}