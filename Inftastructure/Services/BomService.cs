﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Inftastructure.DTO;
using Inftastructure.Entities;
using System.Linq;
using System;

namespace Inftastructure.Services
{
    public class BomService : IBomService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public BomService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(BomForCreationDto element)
        {
            var product = _context.Products.Where(v => v.ProductCode.Equals(element.ProductCode)).FirstOrDefault();
            var parentProduct = _context.Products.Where(v => v.ProductCode.Equals(element.ParentProductCode)).FirstOrDefault();
            //todo child

            var bom = new Bom(product, parentProduct, element.Quantity ?? 0);
            _context.Boms.Add(bom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var bom = _context.Boms.Where(v => v.BomCode.Equals(code)).FirstOrDefault();
            if (bom == null)
                return;

            _context.Boms.Remove(bom);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BomDto>> GetAllAsync()
        {
            var boms = new List<BomDto>();
            foreach (var bom in _context.Boms)
                boms.Add(_mapper.Map<BomDto>(bom));

            await Task.CompletedTask;
            return boms;
        }

        public async Task<BomDto> GetAsync(string code)
        {
            var bom = _context.Boms.FirstOrDefault(v => v.BomCode.Equals(code));
            await Task.CompletedTask;
            return _mapper.Map<BomDto>(bom);
        }

        public async Task UpdateAsync(BomForUpdateDto element)
        {
            var bom = _context.Boms.FirstOrDefault(v => v.BomCode.Equals(element.BomCode));
            if (bom == null)
                throw new ArgumentException("The given bom for an update is invalid.");

            var updatedBom = new Bom
            {
                BomCode = element.BomCode,
                Quantity = element.Quantity ?? bom.Quantity
            };

            // todo

            throw new NotImplementedException("Bom: UpdateAsync");
        }
    }
}
