using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Dtos.Mantenimientos
{
    public class MantenimientoSaveDto
    {
        public DateTime? Fecha { get; set; }
        public int? IdPozo { get; set; }
        public int? IdTipoMantenimiento { get; set; }
        public string? Observaciones { get; set; }
    }
}
