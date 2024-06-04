using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventoryApiRest.Models
{
    public class MovimientoInventario
    {
        public int Id { get; set; }

        [Required]
        public int ProductoId { get; set; }
        
        [ForeignKey("ProductoId")]
        public Producto? Producto { get; set; }
        
        [Required]
        [StringLength(10)]
        public required string TipoMovimiento { get; set; } // 'entrada' o 'salida'
        
        [Required]
        public int Cantidad { get; set; }

        public DateTime FechaMovimiento { get; set; } = DateTime.UtcNow;
        
        public string? Descripcion { get; set; }
    }
}