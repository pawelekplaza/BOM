﻿using System.Collections.Generic;

namespace Inftastructure.DTO
{
    public class BomDto
    {
        public string BomCode { get; set; }
        public string ProductCode { get; set; }
        public string ParentProductCode { get; set; }
        public virtual IEnumerable<string> ChildProductCodes { get; set; }
        public double Quantity { get; set; }
    }
}
