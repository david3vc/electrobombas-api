using Electrobombas.Application.Cores.Exceptions;
using Electrobombas.Application.Dtos.CambioEquipos;
using Electrobombas.Application.Dtos.CambioEquipos.Extensions;
using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Electrobombas.Application.Services.Implementations
{
    public class CambioEquipoService : ICambioEquipoService
    {
        private readonly ICambioEquipoRepository _cambioEquipoRepository;
        public CambioEquipoService(ICambioEquipoRepository cambioEquipoRepository)
        {
            _cambioEquipoRepository = cambioEquipoRepository;
        }

        public async Task<CambioEquipoDto> CreateAsync(CambioEquipoSaveDto saveDto)
        {
            CambioEquipo cambioEquipo = saveDto.ToEntidad();
            cambioEquipo.FechaCreacion = DateTime.UtcNow;
            cambioEquipo.Estado = true;

            await _cambioEquipoRepository.SaveAsync(cambioEquipo);
            return cambioEquipo.ToDto();
        }

        public async Task<CambioEquipoDto> DisabledAsync(int id)
        {
            CambioEquipo? cambioEquipo = await _cambioEquipoRepository.FindByIdAsync(id);
            if (cambioEquipo is null) throw CambioEquipoNotFound(id);

            cambioEquipo.Estado = !cambioEquipo.Estado;

            await _cambioEquipoRepository.SaveAsync(cambioEquipo);
            return cambioEquipo.ToDto();
        }

        public async Task<CambioEquipoDto> EditAsync(int id, CambioEquipoSaveDto saveDto)
        {
            CambioEquipo? cambioEquipo = await _cambioEquipoRepository.FindByIdAsync(id);
            if (cambioEquipo is null) throw CambioEquipoNotFound(id);

            cambioEquipo.ApplyFrom(saveDto);
            cambioEquipo.FechaActualizacion = DateTime.UtcNow;

            await _cambioEquipoRepository.SaveAsync(cambioEquipo);
            return cambioEquipo.ToDto();
        }

        public async Task<IReadOnlyList<CambioEquipoDto>> FindAllAsync()
        {
            IReadOnlyList<CambioEquipo> cambioEquipos = await _cambioEquipoRepository.FindAllAsync();

            return cambioEquipos.ToDtoList();
        }

        public async Task<CambioEquipoDto> FindByIdAsync(int id)
        {
            CambioEquipo? cambioEquipo = await _cambioEquipoRepository.FindByIdAsync(id);
            if (cambioEquipo is null) throw CambioEquipoNotFound(id);

            return cambioEquipo.ToDto();
        }

        private NotFoundCoreException CambioEquipoNotFound(int id)
        {
            return new NotFoundCoreException("Cambio Equipo no encontrado para el id: " + id);
        }
    }
}
