using Electrobombas.Application.Cores.Exceptions;
using Electrobombas.Application.Dtos.Mantenimientos;
using Electrobombas.Application.Dtos.Mantenimientos.Extensions;
using Electrobombas.Application.Dtos.MantenimientoTrabajadores;
using Electrobombas.Application.Dtos.MantenimientoTrabajadores.Extensions;
using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Electrobombas.Application.Services.Implementations
{
    public class MantenimientoTrabajadorService : IMantenimientoTrabajadorService
    {
        public readonly IMantenimientoTrabajadorRepository _mantenimientoTrabajadorRepository;

        public MantenimientoTrabajadorService(IMantenimientoTrabajadorRepository mantenimientoTrabajadorRepository)
        {
            _mantenimientoTrabajadorRepository = mantenimientoTrabajadorRepository;
        }
        public async Task<MantenimientoTrabajadorDto> CreateAsync(MantenimientoTrabajadorSaveDto saveDto)
        {
            MantenimientoTrabajador mantenimientoTrabajador = saveDto.ToEntidad();
            mantenimientoTrabajador.FechaCreacion = DateTime.UtcNow;
            mantenimientoTrabajador.Estado = true;

            await _mantenimientoTrabajadorRepository.SaveAsync(mantenimientoTrabajador);
            return mantenimientoTrabajador.ToDto();
        }

        public async Task<MantenimientoTrabajadorDto> DisabledAsync(int id)
        {
            MantenimientoTrabajador? mantenimientoTrabajador = await _mantenimientoTrabajadorRepository.FindByIdAsync(id);
            if (mantenimientoTrabajador is null) throw MantenimientoNotFound(id);

            mantenimientoTrabajador.Estado = !mantenimientoTrabajador.Estado;

            await _mantenimientoTrabajadorRepository.SaveAsync(mantenimientoTrabajador);
            return mantenimientoTrabajador.ToDto();
        }

        public async Task<MantenimientoTrabajadorDto> EditAsync(int id, MantenimientoTrabajadorSaveDto saveDto)
        {
            MantenimientoTrabajador? mantenimientoTrabajador = await _mantenimientoTrabajadorRepository.FindByIdAsync(id);
            if (mantenimientoTrabajador is null) throw MantenimientoNotFound(id);

            mantenimientoTrabajador.ApplyFrom(saveDto);
            mantenimientoTrabajador.FechaActualizacion = DateTime.UtcNow;

            await _mantenimientoTrabajadorRepository.SaveAsync(mantenimientoTrabajador);
            return mantenimientoTrabajador.ToDto();
        }

        public async Task<IReadOnlyList<MantenimientoTrabajadorDto>> FindAllAsync()
        {
            List<Expression<Func<MantenimientoTrabajador, object>>> includes = new List<Expression<Func<MantenimientoTrabajador, object>>>()
            {
                t => t.Mantenimiento
            };
            IReadOnlyList<MantenimientoTrabajador> mantenimientos = await _mantenimientoTrabajadorRepository.FindAllAsync(includes: includes);

            return mantenimientos.ToDtoList();
        }

        public async Task<MantenimientoTrabajadorDto> FindByIdAsync(int id)
        {
            MantenimientoTrabajador? mantenimientoTrabajador = await _mantenimientoTrabajadorRepository.FindByIdAsync(id);
            if (mantenimientoTrabajador is null) throw MantenimientoNotFound(id);

            return mantenimientoTrabajador.ToDto();
        }

        private NotFoundCoreException MantenimientoNotFound(int id)
        {
            return new NotFoundCoreException("MantenimientoTrabajador no encontrado para el id: " + id);
        }
    }
}
