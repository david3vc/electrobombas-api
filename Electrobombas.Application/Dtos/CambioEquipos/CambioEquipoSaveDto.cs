using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Dtos.CambioEquipos
{
    public class CambioEquipoSaveDto
    {
        public int? IdMantenimiento { get; set; }
        public int? IdTipoEquipo { get; set; }
        public string? MotorMarcaActualAnterior { get; set; }
        public string? MotorMarcaActualNuevo { get; set; }
        public string? SerieAnterior { get; set; }
        public string? SerieNuevo { get; set; }
        public decimal? HpAnterior { get; set; }
        public decimal? HpNuevo { get; set; }
        public decimal? RpmAnterior { get; set; }
        public decimal? RpmNuevo { get; set; }
        public string? Observacion { get; set; }
    }
}
