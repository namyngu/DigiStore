namespace MonashApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public class AspNetUsers_Admin
	{
        public string Id { get; set; }
        public bool isActive { get; set; }

    }
}