using System.Collections.Generic;
using System.Threading.Tasks;
using Inftastructure.DTO;
using Inftastructure.Entities;
using AutoMapper;
using System.Linq;
using System;

namespace Inftastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ProductService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(ProductDto element)
        {
            var supplier = _context.Suppliers.Where(v => v.SupplierCode.Equals(element.SupplierCode)).FirstOrDefault();
            var product = new Product(element.Name, element.Description, supplier);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var product = _context.Products.Where(v => v.ProductCode.Equals(code)).FirstOrDefault();
            if (product == null)
                return;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = new List<ProductDto>();
            var query = _context.Products.Join(_context.Suppliers, 
                product => product.SupplierCode, 
                supplier => supplier.SupplierCode,
                (p, s) => new Product(p.Name, p.Description, s));
            
            foreach (var product in query)
                products.Add(_mapper.Map<ProductDto>(product));

            await Task.CompletedTask;
            return products;
        }

        public async Task<ProductDto> GetAsync(string code)
        {
            var product = _context.Products.FirstOrDefault(v => v.ProductCode.Equals(code));
            await Task.CompletedTask;
            return _mapper.Map<ProductDto>(product);
        }

        public Task UpdateAsync(ProductDto element)
        {
            throw new NotImplementedException("Product: UpdateAsync");
        }
    }
}
