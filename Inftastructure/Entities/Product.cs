using System;
using System.ComponentModel.DataAnnotations;

namespace Inftastructure.Entities
{
    public class Product
    {
        [Key]
        public string Code { get; set; } = Guid.NewGuid().ToString("N");

        [Required(ErrorMessage = "Name of the product is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Supplier Supplier { get; set; }

        protected Product()
        {

        }

        public Product(string name, string description, Supplier supplier)
        {            
            Name = name;
            Description = description;
            Supplier = supplier;
        }
    }
}
