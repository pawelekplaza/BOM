using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inftastructure.Services;
using Inftastructure.DTO;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Suppliers")]
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            return await _supplierService.GetAllAsync();
        }

        // GET: api/Suppliers/5
        [HttpGet("{code}")]
        public async Task<SupplierDto> GetAsync(string code)
        {
            return await _supplierService.GetAsync(code);
        }
        
        // POST: api/Suppliers
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SupplierDto value)
        {
            await _supplierService.CreateAsync(value);
            return Ok();
        }
        
        // PUT: api/Suppliers/5
        [HttpPut("{code}")]
        public async Task<IActionResult> PutAsync(string code, [FromBody]SupplierDto value)
        {
            await _supplierService.UpdateAsync(value);
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteAsync(string code)
        {
            await _supplierService.DeleteAsync(code);
            return NoContent();
        }
    }
}
