using AutoMapper;
using Inftastructure.DTO;
using Inftastructure.Entities;
using System.Linq;

namespace Inftastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {                
                cfg.CreateMap<Supplier, SupplierDto>();

                cfg.CreateMap<Product, ProductDto>()
                    .ForMember(x => x.SupplierCode, m => m.MapFrom(p => p.Supplier.Code));

                cfg.CreateMap<Bom, BomDto>()
                    .ForMember(x => x.ProductCode, m => m.MapFrom(p => p.Product.Code))
                    .ForMember(x => x.ParentProductCode, m => m.MapFrom(p => p.ParentProduct.Code))
                    .ForMember(x => x.ChildProductCodes, m => m.MapFrom(p => p.ChildProducts.Select(v => v.Code)));                
            })
            .CreateMapper();
    }
}
