﻿using System.Collections;
using System.Collections.Generic;

namespace Inftastructure.DTO
{
    public class BomDto
    {
        public string Code { get; set; }
        public string ProductCode { get; set; }
        public string ParentProductCode { get; set; }
        public IEnumerable<string> ChildProductCodes { get; set; }
        public double Quantity { get; set; }
    }
}