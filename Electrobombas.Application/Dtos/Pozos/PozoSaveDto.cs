namespace Electrobombas.Application.Dtos.Pozos
{
    public class PozoSaveDto
    {
        public string? Numero { get; set; }
        public decimal? Diametro { get; set; }
        public decimal? HpActual { get; set; }
        public string? SerieMotorActual { get; set; }
        public string? SerieBombaActual { get; set; }
        public decimal? RpmActual { get; set; }
        public int? IdUbicacion { get; set; }
    }
}
