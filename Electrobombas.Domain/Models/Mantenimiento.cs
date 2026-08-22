namespace Electrobombas.Domain.Models
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdPozo { get; set; }
        public int? IdTipoMantenimiento { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool Estado { get; set; }

        public virtual Pozo? Pozo { get; set; }
        public virtual TablaComun? TipoMantenimiento { get; set; }
        public virtual ICollection<MantenimientoTrabajador>? MantenimientoTrabajadores { get; set; }
    }
}
