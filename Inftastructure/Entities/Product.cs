﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inftastructure.Entities
{
    public class Product
    {
        [Key]
        public string ProductCode { get; set; } = Guid.NewGuid().ToString("N");

        [ForeignKey("SupplierCode")]
        public virtual Supplier Supplier { get; set; }

        [Required(ErrorMessage = "Name of the product is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string SupplierCode { get; set; }        

        public Product()
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
