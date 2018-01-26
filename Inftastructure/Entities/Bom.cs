using Inftastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inftastructure
{
    public class Bom
    {        
        [Key]
        public string BomCode { get; set; } = Guid.NewGuid().ToString("N");

        [Required(ErrorMessage = "Product is required.")]
        [ForeignKey("ProductCode")]
        public Product Product { get; set; }

        [ForeignKey("ParentProductCode")]
        public Product ParentProduct { get; set; }

        [Required(ErrorMessage = "Element's quantity is required.")]
        public double Quantity { get; set; }
        public string ProductCode { get; set; }
        public string ParentProductCode { get; set; }
        public virtual IEnumerable<Product> ChildProducts { get; set; }

        public Bom()
        {

        }

        public Bom(Product product, Product parentProduct, double quantity)
        {
            Product = product;
            ParentProduct = parentProduct;
            Quantity = quantity;            
        }
    }
}
