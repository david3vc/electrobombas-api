using Electrobombas.Domain.Models;

namespace Electrobombas.Application.Dtos.Mantenimientos.Extensions
{
    public static class MantenimientoExtensions
    {
        extension(Mantenimiento mantenimiento)
        {
            public MantenimientoDto ToDto() => new()
            {
                Id = mantenimiento.Id,
                Fecha = mantenimiento.Fecha,
                IdPozo = mantenimiento.IdPozo,
                IdTipoMantenimiento = mantenimiento.IdTipoMantenimiento,
                Observaciones = mantenimiento.Observaciones,
                Estado = mantenimiento.Estado,
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
            public List<MantenimientoDto> ToDtoList() => mantenimientos.Select(m => m.ToDto()).ToList();
        }
    }
}
