using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inftastructure.Entities
{
    public class Supplier
    {
        [Key]
        public string SupplierCode { get; set; } = Guid.NewGuid().ToString("N");

        [Required(ErrorMessage = "Name of the supplier is required.")]
        public string Name { get; set; }
        public string Details { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Supplier()
        {
        }

        public Supplier(string name, string details)
        {
            Name = name;
            Details = details;
        }
    }
}
