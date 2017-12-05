using System.Collections.Generic;

namespace Inftastructure.DTO
{
    public class BomForCreationDto
    {
        public string ProductCode { get; set; }
        public string ParentProductCode { get; set; }
        public IEnumerable<string> ChildProductCodes { get; set; }
        public double? Quantity { get; set; }
    }
}
