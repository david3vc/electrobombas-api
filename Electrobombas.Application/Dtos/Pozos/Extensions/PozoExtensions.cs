using Electrobombas.Application.Dtos.Mantenimientos.Extensions;
using Electrobombas.Application.Dtos.TablaComunes.Extensions;
using Electrobombas.Domain.Models;

namespace Electrobombas.Application.Dtos.Pozos.Extensions
{
    public static class PozoExtensions
    {
        extension(Pozo pozo)
        {
            public PozoDto ToDto() => new()
            {
                Id = pozo.Id,
                Nombre = pozo.Nombre,
                Diametro = pozo.Diametro,
                Ne = pozo.Ne,
                Profundidad = pozo.Profundidad,
                CantidadTubos = pozo.CantidadTubos,
                DiametroTubo = pozo.DiametroTubo,
                Hp = pozo.Hp,
                Voltaje = pozo.Voltaje,
                Amperaje = pozo.Amperaje,
                Rpm = pozo.Rpm,
                CaudalLps = pozo.CaudalLps,
                SerieMotor = pozo.SerieMotor,
                SerieBomba = pozo.SerieBomba,
                NumeroImpulsores = pozo.NumeroImpulsores,
                IdUbicacion = pozo.IdUbicacion,
                Estado = pozo.Estado,
                Ubicacion = pozo?.Ubicacion?.ToDto(),
                Mantenimientos = pozo?.Mantenimientos?.ToDtoList(includePozo: false)
            };

            public void ApplyFrom(PozoSaveDto saveDto)
            {
                pozo.Nombre = saveDto.Nombre;
                pozo.Diametro = saveDto.Diametro;
                pozo.Ne = saveDto.Ne;
                pozo.Profundidad = saveDto.Profundidad;
                pozo.CantidadTubos = saveDto.CantidadTubos;
                pozo.DiametroTubo = saveDto.DiametroTubo;
                pozo.Hp = saveDto.Hp;
                pozo.Voltaje = saveDto.Voltaje;
                pozo.Amperaje = saveDto.Amperaje;
                pozo.Rpm = saveDto.Rpm;
                pozo.CaudalLps = saveDto.CaudalLps;
                pozo.SerieMotor = saveDto.SerieMotor;
                pozo.SerieBomba = saveDto.SerieBomba;
                pozo.NumeroImpulsores = saveDto.NumeroImpulsores;
                pozo.IdUbicacion = saveDto.IdUbicacion;
            }
        }

        extension(PozoSaveDto pozoSave)
        {
            public Pozo ToPozo() => new()
            {
                Nombre = pozoSave?.Nombre,
                Diametro = pozoSave?.Diametro,
                Ne = pozoSave?.Ne,
                Profundidad = pozoSave?.Profundidad,
                CantidadTubos = pozoSave?.CantidadTubos,
                DiametroTubo = pozoSave?.DiametroTubo,
                Hp = pozoSave?.Hp,
                Voltaje = pozoSave?.Voltaje,
                Amperaje = pozoSave?.Amperaje,
                Rpm = pozoSave?.Rpm,
                CaudalLps = pozoSave?.CaudalLps,
                SerieMotor = pozoSave?.SerieMotor,
                SerieBomba = pozoSave?.SerieBomba,
                NumeroImpulsores = pozoSave?.NumeroImpulsores,
                IdUbicacion = pozoSave?.IdUbicacion
            };
        }

        extension(IEnumerable<Pozo> pozos)
        {
            public List<PozoDto> ToDtoList() => pozos.Select(p => p.ToDto()).ToList();
        }
    }
}
