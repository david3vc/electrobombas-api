using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Domain.Models
{
    public class MantenimientoTrabajador
    {
        public int Id { get; set; }
        public int? IdMantenimiento { get; set; }
        public int? IdTrabajador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool Estado { get; set; }

        public virtual Mantenimiento? Mantenimiento { get; set; }
        public virtual TablaComun? Trabajador { get; set; }
    }
}
