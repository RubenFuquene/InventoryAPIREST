using inventoryApiRest.Data;
using inventoryApiRest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inventoryApiRest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosInventarioController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        // GET: api/MovimientosInventario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoInventarioDto>>> GetMovimientosInventario()
        {
            var movimientos = await _context.MovimientosInventario
                .Include(m => m.Producto)
                .Select(m => new MovimientoInventarioDto
                {
                    Id = m.Id,
                    ProductoId = m.ProductoId,
                    TipoMovimiento = m.TipoMovimiento,
                    Cantidad = m.Cantidad,
                    FechaMovimiento = m.FechaMovimiento,
                    Descripcion = m.Descripcion,
                    ProductoNombre = m.Producto.Nombre
                })
                .ToListAsync();

            return Ok(movimientos);
        }

        // GET: api/MovimientosInventario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoInventario>> GetMovimientoInventario(int id)
        {
            var movimientoInventario = await _context.MovimientosInventario
                .Include(m => m.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movimientoInventario == null)
            {
                return NotFound();
            }

            return movimientoInventario;
        }

        // POST: api/MovimientosInventario
        [HttpPost]
        public async Task<ActionResult<MovimientoInventario>> PostMovimientoInventario(MovimientoInventario movimientoInventario)
        {
            _context.MovimientosInventario.Add(movimientoInventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimientoInventario", new { id = movimientoInventario.Id }, movimientoInventario);
        }

        // POST: api/MovimientosInventario/registrarMovimiento
        [HttpPost("registrarMovimiento")]
        public async Task<ActionResult<MovimientoInventario>> RegistrarMovimiento(MovimientoInventario movimientoInventario)
        {
            var result = await _context.MovimientosInventario
                .FromSqlInterpolated($"SELECT * FROM RegistrarMovimiento({movimientoInventario.ProductoId}, {movimientoInventario.TipoMovimiento}, {movimientoInventario.Cantidad}, {movimientoInventario.Descripcion})")
                .SingleOrDefaultAsync();

            if (result == null)
            {
                return BadRequest("No se pudo registrar el movimiento.");
            }

            return Ok(result);
        }

        // PUT: api/MovimientosInventario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimientoInventario(int id, MovimientoInventario movimientoInventario)
        {
            if (id != movimientoInventario.Id)
            {
                return BadRequest();
            }

            _context.Entry(movimientoInventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoInventarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/MovimientosInventario/5
        [HttpDelete("{id}")]
        private async Task<IActionResult> DeleteMovimientoInventario(int id)
        {
            var movimientoInventario = await _context.MovimientosInventario.FindAsync(id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }

            _context.MovimientosInventario.Remove(movimientoInventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovimientoInventarioExists(int id)
        {
            return _context.MovimientosInventario.Any(e => e.Id == id);
        }
    }
}