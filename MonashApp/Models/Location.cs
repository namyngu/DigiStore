namespace MonashApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Location
    {
        public int Id { get; set; }

        [Required]
        public string StreetAdress { get; set; }

        [Required]
        public string Suburb { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }
    }
}
