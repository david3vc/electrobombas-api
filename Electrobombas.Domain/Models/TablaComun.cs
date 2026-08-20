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
    }
}
