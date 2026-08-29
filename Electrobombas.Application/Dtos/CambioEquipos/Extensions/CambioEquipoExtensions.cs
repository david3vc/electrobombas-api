using Electrobombas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Dtos.CambioEquipos.Extensions
{
    public static class CambioEquipoExtensions
    {
        extension(CambioEquipo cambioEquipo)
        {
            public CambioEquipoDto ToDto() => new()
            {
                Id = cambioEquipo.Id,
                IdMantenimiento = cambioEquipo.IdMantenimiento,
                IdTipoEquipo = cambioEquipo.IdTipoEquipo,
                MotorMarcaActualAnterior = cambioEquipo.MotorMarcaActualAnterior,
                MotorMarcaActualNuevo = cambioEquipo.MotorMarcaActualNuevo,
                SerieAnterior = cambioEquipo.SerieAnterior,
                SerieNuevo = cambioEquipo.SerieNuevo,
                HpAnterior = cambioEquipo.HpAnterior,
                HpNuevo = cambioEquipo.HpNuevo,
                RpmAnterior = cambioEquipo.RpmAnterior,
                RpmNuevo = cambioEquipo.RpmNuevo,
                Observacion = cambioEquipo.Observacion,
                Estado = cambioEquipo.Estado,
            };

            public void ApplyFrom(CambioEquipoSaveDto saveDto)
            {
                cambioEquipo.IdMantenimiento = saveDto.IdMantenimiento;
                cambioEquipo.IdTipoEquipo = saveDto.IdTipoEquipo;
                cambioEquipo.MotorMarcaActualAnterior = saveDto.MotorMarcaActualAnterior;
                cambioEquipo.MotorMarcaActualNuevo = saveDto.MotorMarcaActualNuevo;
                cambioEquipo.SerieAnterior = saveDto.SerieAnterior;
                cambioEquipo.SerieNuevo = saveDto.SerieNuevo;
                cambioEquipo.HpAnterior = saveDto.HpAnterior;
                cambioEquipo.HpNuevo = saveDto.HpNuevo;
                cambioEquipo.RpmAnterior = saveDto.RpmAnterior;
                cambioEquipo.RpmNuevo = saveDto.RpmNuevo;
                cambioEquipo.Observacion = saveDto.Observacion;
            }
        }

        extension(CambioEquipoSaveDto saveDto)
        {
            public CambioEquipo ToEntidad() => new()
            {
                IdMantenimiento = saveDto?.IdMantenimiento,
                IdTipoEquipo = saveDto?.IdTipoEquipo,
                MotorMarcaActualAnterior = saveDto?.MotorMarcaActualAnterior,
                MotorMarcaActualNuevo = saveDto?.MotorMarcaActualNuevo,
                SerieAnterior = saveDto?.SerieAnterior,
                SerieNuevo = saveDto?.SerieNuevo,
                HpAnterior = saveDto?.HpAnterior,
                HpNuevo = saveDto?.HpNuevo,
                RpmAnterior = saveDto?.RpmAnterior,
                RpmNuevo = saveDto?.RpmNuevo,
                Observacion = saveDto?.Observacion,
            };
        }

        extension(IEnumerable<CambioEquipo> mantenimientos)
        {
            public List<CambioEquipoDto> ToDtoList(bool includePozo = true) => mantenimientos.Select(m => m.ToDto()).ToList();
        }
    }
}
