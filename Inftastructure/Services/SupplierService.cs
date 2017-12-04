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
            var supplier = _context.Suppliers.Where(v => v.SupplierCode.Equals(code)).FirstOrDefault();
            if (supplier == null)
                return;

            _context.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var suppliers = new List<SupplierDto>();
            foreach (var supplier in _context.Suppliers)
                suppliers.Add(_mapper.Map<SupplierDto>(supplier));

            await Task.CompletedTask;
            return suppliers;
        }

        public async Task<SupplierDto> GetAsync(string code)
        {
            var supplier = _context.Suppliers.FirstOrDefault(v => v.SupplierCode.Equals(code));
            await Task.CompletedTask;
            return _mapper.Map<SupplierDto>(supplier);
        }

        public Task UpdateAsync(SupplierDto element)
        {
            throw new System.NotImplementedException();
        }
    }
}
