using Electrobombas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Dtos.MedicionMantenimientos.Extensions
{
    public static class MedicionMantenimientoExtensions
    {
        extension(MedicionMantenimiento medicionMantenimiento)
        {
            public MedicionMantenimientoDto ToDto() => new()
            {
                IdMantenimiento = medicionMantenimiento.IdMantenimiento,
                NivelEstatico = medicionMantenimiento.NivelEstatico,
                Profundidad = medicionMantenimiento.Profundidad,
                CantidadTubos = medicionMantenimiento.CantidadTubos,
                DiametroTubo = medicionMantenimiento.DiametroTubo,
                Voltaje = medicionMantenimiento.Voltaje,
                Amperaje = medicionMantenimiento.Amperaje,
                CaudalLps = medicionMantenimiento.CaudalLps,
                NumeroImpulsores = medicionMantenimiento.NumeroImpulsores,
                Estado = medicionMantenimiento.Estado
            };

            public void ApplyFrom(MedicionMantenimientoSaveDto saveDto)
            {
                medicionMantenimiento.IdMantenimiento = saveDto.IdMantenimiento;
                medicionMantenimiento.NivelEstatico = saveDto.NivelEstatico;
                medicionMantenimiento.Profundidad = saveDto.Profundidad;
                medicionMantenimiento.CantidadTubos = saveDto.CantidadTubos;
                medicionMantenimiento.DiametroTubo = saveDto.DiametroTubo;
                medicionMantenimiento.Voltaje = saveDto.Voltaje;
                medicionMantenimiento.Amperaje = saveDto.Amperaje;
                medicionMantenimiento.CaudalLps = saveDto.CaudalLps;
                medicionMantenimiento.NumeroImpulsores = saveDto.NumeroImpulsores;
            }
        }

        extension(MedicionMantenimientoSaveDto mantenimientoSave)
        {
            public MedicionMantenimiento ToEntidad() => new()
            {
                IdMantenimiento = mantenimientoSave.IdMantenimiento,
                NivelEstatico = mantenimientoSave.NivelEstatico,
                Profundidad = mantenimientoSave.Profundidad,
                CantidadTubos = mantenimientoSave.CantidadTubos,
                DiametroTubo = mantenimientoSave.DiametroTubo,
                Voltaje = mantenimientoSave.Voltaje,
                Amperaje = mantenimientoSave.Amperaje,
                CaudalLps = mantenimientoSave.CaudalLps,
                NumeroImpulsores = mantenimientoSave.NumeroImpulsores,
            };
        }

        extension(IEnumerable<MedicionMantenimiento> mantenimientos)
        {
            public List<MedicionMantenimientoDto> ToDtoList() => mantenimientos.Select(m => m.ToDto()).ToList();
        }
    }
}
