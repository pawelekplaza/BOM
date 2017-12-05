using Inftastructure.DTO;

namespace Inftastructure.Services
{
    public interface IProductService : IService<ProductDto, ProductForCreationDto, ProductForUpdateDto>
    {
    }
}
