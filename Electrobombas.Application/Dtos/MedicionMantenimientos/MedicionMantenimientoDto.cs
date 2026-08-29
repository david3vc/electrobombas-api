using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Dtos.MedicionMantenimientos
{
    public class MedicionMantenimientoDto
    {
        public int Id { get; set; }
        public int? IdMantenimiento { get; set; }
        public decimal? NivelEstatico { get; set; }
        public decimal? Profundidad { get; set; }
        public decimal? CantidadTubos { get; set; }
        public decimal? DiametroTubo { get; set; }
        public decimal? Voltaje { get; set; }
        public decimal? Amperaje { get; set; }
        public decimal? CaudalLps { get; set; }
        public int? NumeroImpulsores { get; set; }
        public bool Estado { get; set; }
    }
}
