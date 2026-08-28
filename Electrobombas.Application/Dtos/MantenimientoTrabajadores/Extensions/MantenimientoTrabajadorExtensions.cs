using Electrobombas.Application.Dtos.Mantenimientos;
using Electrobombas.Application.Dtos.Mantenimientos.Extensions;
using Electrobombas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Dtos.MantenimientoTrabajadores.Extensions
{
    public static class MantenimientoTrabajadorExtensions
    {
        extension(MantenimientoTrabajador mantenimientoTrabajador)
        {
            public MantenimientoTrabajadorDto ToDto(bool includeMantenimiento = true) => new()
            {
                Id = mantenimientoTrabajador.Id,
                IdMantenimiento = mantenimientoTrabajador.IdMantenimiento,
                IdTrabajador = mantenimientoTrabajador.IdTrabajador,
                Estado = mantenimientoTrabajador.Estado,
                Mantenimiento = includeMantenimiento ? mantenimientoTrabajador?.Mantenimiento?.ToDto() : null,
            };

            public void ApplyFrom(MantenimientoTrabajadorSaveDto saveDto)
            {
                mantenimientoTrabajador.IdMantenimiento = saveDto.IdMantenimiento;
                mantenimientoTrabajador.IdTrabajador = saveDto.IdTrabajador;
            }
        }

        extension(MantenimientoTrabajadorSaveDto saveDto)
        {
            public MantenimientoTrabajador ToEntidad() => new()
            {
                IdMantenimiento = saveDto?.IdMantenimiento,
                IdTrabajador = saveDto?.IdTrabajador,
            };
        }

        extension(IEnumerable<MantenimientoTrabajador> mantenimientoTrabajadores)
        {
            public List<MantenimientoTrabajadorDto> ToDtoList(bool includeMantenimiento = true) => mantenimientoTrabajadores.Select(m => m.ToDto(includeMantenimiento)).ToList();
        }
    }
}
