using Electrobombas.Application.Dtos.MantenimientoTrabajadores.Extensions;
using Electrobombas.Application.Dtos.Pozos.Extensions;
using Electrobombas.Application.Dtos.TablaComunes.Extensions;
using Electrobombas.Domain.Models;

namespace Electrobombas.Application.Dtos.Mantenimientos.Extensions
{
    public static class MantenimientoExtensions
    {
        extension(Mantenimiento mantenimiento)
        {
            public MantenimientoDto ToDto(bool includePozo = true) => new()
            {
                Id = mantenimiento.Id,
                Fecha = mantenimiento.Fecha,
                IdPozo = mantenimiento.IdPozo,
                IdTipoMantenimiento = mantenimiento.IdTipoMantenimiento,
                Observaciones = mantenimiento.Observaciones,
                Estado = mantenimiento.Estado,
                Pozo = includePozo ? mantenimiento?.Pozo?.ToDto() : null,
                TipoMantenimiento = mantenimiento?.TipoMantenimiento?.ToDto(),
                Trabajadores = mantenimiento?.MantenimientoTrabajadores?.ToDtoList(includeMantenimiento: false)
            };

            public void ApplyFrom(MantenimientoSaveDto saveDto)
            {
                mantenimiento.Fecha = saveDto.Fecha;
                mantenimiento.IdPozo = saveDto.IdPozo;
                mantenimiento.IdTipoMantenimiento = saveDto.IdTipoMantenimiento;
                mantenimiento.Observaciones = saveDto.Observaciones;
            }
        }

        extension(MantenimientoSaveDto mantenimientoSave)
        {
            public Mantenimiento ToMantenimiento() => new()
            {
                Fecha = mantenimientoSave?.Fecha,
                IdPozo = mantenimientoSave?.IdPozo,
                IdTipoMantenimiento = mantenimientoSave?.IdTipoMantenimiento,
                Observaciones = mantenimientoSave?.Observaciones,
            };
        }

        extension(IEnumerable<Mantenimiento> mantenimientos)
        {
            public List<MantenimientoDto> ToDtoList(bool includePozo = true) => mantenimientos.Select(m => m.ToDto(includePozo)).ToList();
        }
    }
}
