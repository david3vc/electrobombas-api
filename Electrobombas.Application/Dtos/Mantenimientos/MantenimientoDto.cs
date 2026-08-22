namespace Electrobombas.Application.Dtos.Mantenimientos
{
    public class MantenimientoDto
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdPozo { get; set; }
        public int? IdTipoMantenimiento { get; set; }
        public string? Observaciones { get; set; }
        public bool Estado { get; set; }
    }
}
