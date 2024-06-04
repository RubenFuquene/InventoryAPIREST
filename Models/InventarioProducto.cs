namespace inventoryApiRest.Models
{
    public class InventarioProducto
    {
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
        public required string Nombre { get; set; }
        public int InventarioActual { get; set; }
    }
}
