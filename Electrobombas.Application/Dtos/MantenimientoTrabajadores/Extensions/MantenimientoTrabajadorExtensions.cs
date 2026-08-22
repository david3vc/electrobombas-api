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
            public MantenimientoTrabajadorDto ToDto() => new()
            {
                Id = mantenimientoTrabajador.Id,
                IdMantenimiento = mantenimientoTrabajador.IdMantenimiento,
                IdTrabajador = mantenimientoTrabajador.IdTrabajador,
                Estado = mantenimientoTrabajador.Estado
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
            public List<MantenimientoTrabajadorDto> ToDtoList() => mantenimientoTrabajadores.Select(m => m.ToDto()).ToList();
        }
    }
}
