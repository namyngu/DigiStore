namespace MonashApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CreditCard
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public DateTime ExpiryDate { get; set; }

        public short Cvv { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUser_Id { get; set; }
    }
}
