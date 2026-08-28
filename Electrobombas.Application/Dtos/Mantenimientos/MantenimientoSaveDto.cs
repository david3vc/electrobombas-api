namespace Electrobombas.Application.Dtos.Mantenimientos
{
    public class MantenimientoSaveDto
    {
        public DateTime? Fecha { get; set; }
        public TimeOnly? HoraInicio { get; set; }
        public TimeOnly? HoraFin { get; set; }
        public int? IdPozo { get; set; }
        public int? IdTipoMantenimiento { get; set; }
        public string? Observaciones { get; set; }
    }
}
