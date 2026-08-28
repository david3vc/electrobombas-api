using Electrobombas.Application.Dtos.Mantenimientos;
using Electrobombas.Application.Dtos.TablaComunes;

namespace Electrobombas.Application.Dtos.Pozos
{
    public class PozoDto
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public decimal? Diametro { get; set; }
        public decimal? HpActual { get; set; }
        public string? SerieMotorActual { get; set; }
        public string? SerieBombaActual { get; set; }
        public decimal? RpmActual { get; set; }
        public int? IdUbicacion { get; set; }
        public bool Estado { get; set; }
        public TablaComunDto? Ubicacion { get; set; }
        public List<MantenimientoDto>? Mantenimientos { get; set; }
    }
}
