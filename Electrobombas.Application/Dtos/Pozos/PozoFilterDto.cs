namespace Electrobombas.Application.Dtos.Pozos
{
    public class PozoFilterDto
    {
        public string? Numero { get; set; }
        public decimal? Diametro { get; set; }
        public decimal? Ne { get; set; }
        public decimal? Profundidad { get; set; }
        public decimal? CantidadTubos { get; set; }
        public decimal? DiametroTubo { get; set; }
        public decimal? CaudalLps { get; set; }
        public int? NumeroImpulsores { get; set; }
        public int? IdUbicacion { get; set; }
        public bool? Estado { get; set; }
    }
}
