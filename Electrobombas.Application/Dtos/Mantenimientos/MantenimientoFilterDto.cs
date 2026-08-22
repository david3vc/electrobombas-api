namespace Electrobombas.Application.Dtos.Mantenimientos
{
    public class MantenimientoFilterDto
    {
        public DateTime? Fecha { get; set; }
        public int? IdPozo { get; set; }
        public int? IdTipoMantenimiento { get; set; }
        public string? Observaciones { get; set; }
        public bool? Estado { get; set; }
    }
}
