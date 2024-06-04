using inventoryApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace inventoryApiRest.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<MovimientoInventario> MovimientosInventario { get; set; }
    public DbSet<LoginModel> Login { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>()
            .HasMany(c => c.Productos)
            .WithOne(p => p.Categoria)
            .HasForeignKey(p => p.CategoriaId);

        modelBuilder.Entity<Producto>()
            .HasMany(p => p.MovimientosInventario)
            .WithOne(m => m.Producto)
            .HasForeignKey(m => m.ProductoId);
    }

    // Método para obtener inventario total
    public async Task<List<InventarioProducto>> CalcularInventarioTotalAsync()
    {
        return await Set<InventarioProducto>()
            .FromSqlRaw("SELECT * FROM CalcularInventarioTotal()")
            .ToListAsync();
    }
}
