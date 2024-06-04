namespace inventoryApiRest.Models
{
    public class MovimientoInventarioDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public required string TipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string? Descripcion { get; set; }
        public string? ProductoNombre { get; set; }
    }
}