using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Dtos.Pozos
{
    public class PozoDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal? Diametro { get; set; }
        public decimal? Ne { get; set; }
        public decimal? Profundidad { get; set; }
        public decimal? CantidadTubos { get; set; }
        public decimal? DiametroTubo { get; set; }
        public decimal? Hp { get; set; }
        public decimal? Voltaje { get; set; }
        public decimal? Amperaje { get; set; }
        public decimal? Rpm { get; set; }
        public decimal? CaudalLps { get; set; }
        public string? SerieMotor { get; set; }
        public string? SerieBomba { get; set; }
        public int? NumeroImpulsores { get; set; }
        public int? IdUbicacion { get; set; }
    }
}
