namespace Electrobombas.Domain.Models
{
    public class TablaComun
    {
        public int Id { get; set; }
        public int IdTabla { get; set; }
        public int IdFila { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Pozo>? Pozos { get; set; }
        public virtual ICollection<Mantenimiento>? Mantenimientos { get; set; }
        public virtual ICollection<MantenimientoTrabajador>? MantenimientoTrabajadores { get; set; }
        public virtual ICollection<CambioEquipo>? CambioEquipos { get; set; }
    }
}
