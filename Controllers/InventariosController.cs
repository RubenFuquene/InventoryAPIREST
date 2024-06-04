using inventoryApiRest.Data;
using inventoryApiRest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace inventoryApiRest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        // GET: api/inventarios/todos
        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<InventarioProducto>>> GetInventarioTotal()
        {
            var inventarioTotal = await _context.CalcularInventarioTotalAsync();
            return Ok(inventarioTotal);
        }
    }
}