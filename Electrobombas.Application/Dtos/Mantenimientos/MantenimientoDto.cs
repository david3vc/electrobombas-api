using Electrobombas.Application.Dtos.MantenimientoTrabajadores;
using Electrobombas.Application.Dtos.Pozos;
using Electrobombas.Application.Dtos.TablaComunes;

namespace Electrobombas.Application.Dtos.Mantenimientos
{
    public class MantenimientoDto
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeOnly? HoraInicio { get; set; }
        public TimeOnly? HoraFin { get; set; }
        public int? IdPozo { get; set; }
        public int? IdTipoMantenimiento { get; set; }
        public string? Observaciones { get; set; }
        public bool Estado { get; set; }
        public PozoDto? Pozo { get; set; }
        public TablaComunDto? TipoMantenimiento { get; set; }
        public List<MantenimientoTrabajadorDto>? Trabajadores { get; set; }
    }
}
