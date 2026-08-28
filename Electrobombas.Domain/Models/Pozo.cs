namespace Electrobombas.Domain.Models
{
    public class Pozo
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public decimal? Diametro { get; set; }
        public decimal? HpActual { get; set; }
        public string? SerieMotorActual { get; set; }
        public string? SerieBombaActual { get; set; }
        public decimal? RpmActual { get; set; }
        public int? IdUbicacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool Estado { get; set; }

        public virtual TablaComun? Ubicacion { get; set; }
        public virtual ICollection<Mantenimiento>? Mantenimientos { get; set; }
    }
}
