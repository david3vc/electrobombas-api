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
                Numero = pozo.Numero,
                Diametro = pozo.Diametro,
                //Ne = pozo.Ne,
                //Profundidad = pozo.Profundidad,
                //CantidadTubos = pozo.CantidadTubos,
                //DiametroTubo = pozo.DiametroTubo,
                HpActual = pozo.HpActual,
                //Voltaje = pozo.Voltaje,
                //Amperaje = pozo.Amperaje,
                RpmActual = pozo.RpmActual,
                //CaudalLps = pozo.CaudalLps,
                SerieMotorActual = pozo.SerieMotorActual,
                SerieBombaActual = pozo.SerieBombaActual,
                //NumeroImpulsores = pozo.NumeroImpulsores,
                IdUbicacion = pozo.IdUbicacion,
                Estado = pozo.Estado,
                Ubicacion = pozo?.Ubicacion?.ToDto(),
                Mantenimientos = pozo?.Mantenimientos?.ToDtoList(includePozo: false)
            };

            public void ApplyFrom(PozoSaveDto saveDto)
            {
                pozo.Numero = saveDto.Numero;
                pozo.Diametro = saveDto.Diametro;
                //pozo.Ne = saveDto.Ne;
                //pozo.Profundidad = saveDto.Profundidad;
                //pozo.CantidadTubos = saveDto.CantidadTubos;
                //pozo.DiametroTubo = saveDto.DiametroTubo;
                pozo.HpActual = saveDto.HpActual;
                //pozo.Voltaje = saveDto.Voltaje;
                //pozo.Amperaje = saveDto.Amperaje;
                pozo.RpmActual = saveDto.RpmActual;
                //pozo.CaudalLps = saveDto.CaudalLps;
                pozo.SerieMotorActual = saveDto.SerieMotorActual;
                pozo.SerieBombaActual = saveDto.SerieBombaActual;
                //pozo.NumeroImpulsores = saveDto.NumeroImpulsores;
                pozo.IdUbicacion = saveDto.IdUbicacion;
            }
        }

        extension(PozoSaveDto pozoSave)
        {
            public Pozo ToPozo() => new()
            {
                Numero = pozoSave?.Numero,
                Diametro = pozoSave?.Diametro,
                //Ne = pozoSave?.Ne,
                //Profundidad = pozoSave?.Profundidad,
                //CantidadTubos = pozoSave?.CantidadTubos,
                //DiametroTubo = pozoSave?.DiametroTubo,
                HpActual = pozoSave?.HpActual,
                //Voltaje = pozoSave?.Voltaje,
                //Amperaje = pozoSave?.Amperaje,
                RpmActual = pozoSave?.RpmActual,
                //CaudalLps = pozoSave?.CaudalLps,
                SerieMotorActual = pozoSave?.SerieMotorActual,
                SerieBombaActual = pozoSave?.SerieBombaActual,
                //NumeroImpulsores = pozoSave?.NumeroImpulsores,
                IdUbicacion = pozoSave?.IdUbicacion
            };
        }

        extension(IEnumerable<Pozo> pozos)
        {
            public List<PozoDto> ToDtoList() => pozos.Select(p => p.ToDto()).ToList();
        }
    }
}
