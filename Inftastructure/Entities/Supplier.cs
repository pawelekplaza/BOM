using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inftastructure.Entities
{
    public class Supplier
    {
        [Key]        
        public string SupplierCode { get; set; } = Guid.NewGuid().ToString("N");

        [Required(ErrorMessage = "Name of the supplier is required.")]
        public string Name { get; set; }
        public string Details { get; set; }

        protected Supplier()
        {
        }

        public Supplier(string name, string details)
        {
            Name = name;
            Details = details;
        }
    }
}
