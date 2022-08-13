namespace MonashApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            CustomerReviews = new HashSet<CustomerReview>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageLink { get; set; }

        public decimal BasePrice { get; set; }

        public int BrandId { get; set; }

        public int OnHand { get; set; }

        public int CommittedToOrder { get; set; }

        public int Backorder { get; set; }

        public int Available { get; set; }

        public int SubCategoryId { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerReview> CustomerReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        [NotMapped]
        public List<Brand> Brands { get; set; }

        [NotMapped]
        public List<SubCategory> SubCategories { get; set; }
    }
}
