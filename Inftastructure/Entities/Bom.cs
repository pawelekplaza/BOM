using Inftastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inftastructure
{
    public class Bom
    {
        [Key]
        public string BomCode { get; set; } = Guid.NewGuid().ToString("N");

        [Required(ErrorMessage = "Product is required.")]
        public Product Product { get; set; }

        [Required(ErrorMessage = "Element's quantity is required.")]
        public double Quantity { get; set; }

        public Product ParentProduct { get; set; }
        public IEnumerable<Product> ChildProducts { get; set; }

        protected Bom()
        {

        }

        public Bom(Product product, Product parentProduct, double quantity, IEnumerable<Product> childProducts = null)
        {            
            Product = product;
            ParentProduct = parentProduct;
            Quantity = quantity;
            ChildProducts = childProducts;
        }
    }
}
