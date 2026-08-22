using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Dtos.MantenimientoTrabajadores
{
    public class MantenimientoTrabajadorDto
    {
        public int Id { get; set; }
        public int? IdMantenimiento { get; set; }
        public int? IdTrabajador { get; set; }
        public bool Estado { get; set; }
    }
}
