using System.ComponentModel.DataAnnotations;

namespace inventoryApiRest.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<Producto>? Productos { get; set; }
    }
}