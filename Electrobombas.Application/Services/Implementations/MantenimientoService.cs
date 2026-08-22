using Electrobombas.Application.Cores.Dtos;
using Electrobombas.Application.Cores.Exceptions;
using Electrobombas.Application.Cores.Extensions;
using Electrobombas.Application.Dtos.Mantenimientos;
using Electrobombas.Application.Dtos.Mantenimientos.Extensions;
using Electrobombas.Domain.Cores.Models;
using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Electrobombas.Application.Services.Implementations
{
    public class MantenimientoService : IMantenimientoService
    {
        private readonly IMantenimientoRepository _mantenimientoRepository;

        public MantenimientoService(IMantenimientoRepository mantenimientoRepository)
        {
            _mantenimientoRepository = mantenimientoRepository;
        }
        public async Task<MantenimientoDto> CreateAsync(MantenimientoSaveDto saveDto)
        {
            Mantenimiento mantenimiento = saveDto.ToMantenimiento();
            mantenimiento.FechaCreacion = DateTime.UtcNow;
            mantenimiento.Estado = true;

            await _mantenimientoRepository.SaveAsync(mantenimiento);
            return mantenimiento.ToDto();
        }

        public async Task<MantenimientoDto> DisabledAsync(int id)
        {
            Mantenimiento? mantenimiento = await _mantenimientoRepository.FindByIdAsync(id);
            if (mantenimiento is null) throw MantenimientoNotFound(id);

            mantenimiento.Estado = !mantenimiento.Estado;

            await _mantenimientoRepository.SaveAsync(mantenimiento);
            return mantenimiento.ToDto();
        }

        public async Task<MantenimientoDto> EditAsync(int id, MantenimientoSaveDto saveDto)
        {
            Mantenimiento? mantenimiento = await _mantenimientoRepository.FindByIdAsync(id);
            if (mantenimiento is null) throw MantenimientoNotFound(id);

            mantenimiento.ApplyFrom(saveDto);
            mantenimiento.FechaActualizacion = DateTime.UtcNow;

            await _mantenimientoRepository.SaveAsync(mantenimiento);
            return mantenimiento.ToDto();
        }

        public async Task<IReadOnlyList<MantenimientoDto>> FindAllAsync()
        {
            IReadOnlyList<Mantenimiento> mantenimientos = await _mantenimientoRepository.FindAllAsync();

            return mantenimientos.ToDtoList();
        }

        public async Task<PageResponse<MantenimientoDto>> FindAllPaginatedAsync(PageRequest<MantenimientoFilterDto> request)
        {
            var filter = request.Filter ?? new MantenimientoFilterDto();
            var paging = new Paging() { PageNumber = request.Page, PageSize = request.PerPage };

            Expression<Func<Mantenimiento, bool>> predicate = x =>
                (!filter.IdPozo.HasValue || x.IdPozo == filter.IdPozo)
                && (!filter.IdTipoMantenimiento.HasValue || x.IdTipoMantenimiento == filter.IdTipoMantenimiento)
                && (!filter.Estado.HasValue || x.Estado == filter.Estado);

            List<Expression<Func<Mantenimiento, object>>> includes = new List<Expression<Func<Mantenimiento, object>>>()
            {
                t => t.TipoMantenimiento
            };

            var response = await _mantenimientoRepository.FindAllPaginatedAsync(paging: paging, predicate: predicate, includes: includes);

            return response.ToPageResponse(m => m.ToDto());
        }

        public async Task<MantenimientoDto> FindByIdAsync(int id)
        {
            Mantenimiento? mantenimiento = await _mantenimientoRepository.FindByIdAsync(id);
            if (mantenimiento is null) throw MantenimientoNotFound(id);

            return mantenimiento.ToDto();
        }

        private NotFoundCoreException MantenimientoNotFound(int id)
        {
            return new NotFoundCoreException("Mantenimiento no encontrado para el id: " + id);
        }
    }
}
