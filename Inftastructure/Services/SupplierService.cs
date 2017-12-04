using System.Collections.Generic;
using System.Threading.Tasks;
using Inftastructure.DTO;
using Inftastructure.Entities;
using AutoMapper;
using System.Linq;

namespace Inftastructure.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public SupplierService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }    

        public async Task CreateAsync(SupplierDto element)
        {
            var supplier = new Supplier(element.Name, element.Details);
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var supplier = _context.Suppliers.Where(v => v.Code.Equals(code)).FirstOrDefault();
            if (supplier == null)
                return;

            _context.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<SupplierDto> GetAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(SupplierDto element)
        {
            throw new System.NotImplementedException();
        }
    }
}
