using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inftastructure.Services
{
    public interface IService<T, TCreation, TUpdate>
    {
        Task CreateAsync(TCreation element);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(string code);
        Task UpdateAsync(TUpdate element);
        Task DeleteAsync(string code);
    }
}
