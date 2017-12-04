using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inftastructure.Services
{
    public interface IService<T>
    {
        Task CreateAsync(T element);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(string code);
        Task UpdateAsync(T element);
        Task DeleteAsync(string code);
    }
}
