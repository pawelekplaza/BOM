using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inftastructure.Services;
using AutoMapper;
using System.Collections;
using Inftastructure.DTO;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;        

        public ProductsController(IProductService productService)
        {
            _productService = productService;            
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await _productService.GetAllAsync();
        }

        // GET: api/Products/5
        [HttpGet("{code}")]
        public async Task<ProductDto> GetAsync(string code)
        {
            return await _productService.GetAsync(code);
        }
        
        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]ProductDto value)
        {
            await _productService.CreateAsync(value);
            return Ok();
        }
        
        // PUT: api/Products/5
        [HttpPut("{code}")]
        public async Task<IActionResult> PutAsync(string code, [FromBody]ProductDto value)
        {
            await _productService.UpdateAsync(value);
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteAsync(string code)
        {
            await _productService.DeleteAsync(code);
            return NoContent();
        }
    }
}
