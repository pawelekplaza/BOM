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
    [Route("api/Boms")]
    public class BomsController : Controller
    {
        private readonly IBomService _bomService;

        public BomsController(IBomService bomService)
        {
            _bomService = bomService;
        }

        // GET: api/Boms
        [HttpGet]
        public async Task<IEnumerable<BomDto>> GetAllAsync()
        {
            return await _bomService.GetAllAsync();
        }

        // GET: api/Boms/312d1f2d23r52rdf23
        [HttpGet("{code}")]
        public async Task<BomDto> GetAsync(string code)
        {
            return await _bomService.GetAsync(code);
        }
        
        // POST: api/Boms
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]BomDto value)
        {
            await _bomService.CreateAsync(value);
            return Ok();
        }
        
        // PUT: api/Boms/5
        [HttpPut("{code}")]
        public async Task<IActionResult> PutAsync(string code, [FromBody]BomDto value)
        {
            await _bomService.UpdateAsync(value);
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            await _bomService.DeleteAsync(code);
            return NoContent();
        }
    }
}
