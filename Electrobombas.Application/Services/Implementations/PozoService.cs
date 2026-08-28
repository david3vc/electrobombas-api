using Electrobombas.Application.Cores.Dtos;
using Electrobombas.Application.Cores.Exceptions;
using Electrobombas.Application.Cores.Extensions;
using Electrobombas.Application.Dtos.Mantenimientos.Extensions;
using Electrobombas.Application.Dtos.Pozos;
using Electrobombas.Application.Dtos.Pozos.Extensions;
using Electrobombas.Domain.Cores.Models;
using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;
using System.Linq.Expressions;

namespace Electrobombas.Application.Services.Implementations
{
    public class PozoService : IPozoService
    {
        private readonly IPozoRepository _pozoRepository;

        public PozoService(IPozoRepository pozoRepository)
        {
            _pozoRepository = pozoRepository;
        }
        public async Task<PozoDto> CreateAsync(PozoSaveDto saveDto)
        {
            Pozo pozo = saveDto.ToPozo();
            pozo.FechaCreacion = DateTime.UtcNow;
            pozo.Estado = true;

            await _pozoRepository.SaveAsync(pozo);
            return pozo.ToDto();
        }

        public async Task<PozoDto> DisabledAsync(int id)
        {
            Pozo? pozo = await _pozoRepository.FindByIdAsync(id);
            if (pozo is null) throw PozoNotFound(id);

            pozo.Estado = !pozo.Estado;

            await _pozoRepository.SaveAsync(pozo);
            return pozo.ToDto();
        }

        public async Task<PozoDto> EditAsync(int id, PozoSaveDto saveDto)
        {
            Pozo? pozo = await _pozoRepository.FindByIdAsync(id);
            if (pozo is null) throw PozoNotFound(id);

            pozo.ApplyFrom(saveDto);
            pozo.FechaActualizacion = DateTime.UtcNow;

            await _pozoRepository.SaveAsync(pozo);
            return pozo.ToDto();
        }

        public async Task<IReadOnlyList<PozoDto>> FindAllAsync()
        {
            List<Expression<Func<Pozo, object>>> includes = new()
            {
                p => p.Ubicacion,
                p => p.Mantenimientos
            };
            IReadOnlyList<Pozo> pozos = await _pozoRepository.FindAllAsync(includes: includes);

            return pozos.ToDtoList();
        }

        public async Task<PageResponse<PozoDto>> FindAllPaginatedAsync(PageRequest<PozoFilterDto> request)
        {
            var filter = request.Filter ?? new PozoFilterDto();
            var paging = new Paging() { PageNumber = request.Page, PageSize = request.PerPage };

            Expression<Func<Pozo, bool>> predicate = x =>
                (string.IsNullOrWhiteSpace(filter.Numero) || x.Numero.ToUpper().Contains(filter.Numero.ToUpper()))
                && (!filter.IdUbicacion.HasValue || x.IdUbicacion == filter.IdUbicacion)
                && (!filter.Estado.HasValue || x.Estado == filter.Estado);

            List<Expression<Func<Pozo, object>>> includes = new List<Expression<Func<Pozo, object>>>()
            {
                t => t.Ubicacion,
                t => t.Mantenimientos
            };

            var response = await _pozoRepository.FindAllPaginatedAsync(paging: paging, predicate: predicate, includes: includes);

            return response.ToPageResponse(p => p.ToDto());
        }

        public async Task<PozoDto> FindByIdAsync(int id)
        {
            Expression<Func<Pozo, bool>> predicate = x => (x.Id == id);
            List<Expression<Func<Pozo, object>>> includes = new()
            {
                p => p.Ubicacion,
                p => p.Mantenimientos
            };
            Pozo? pozo = await _pozoRepository.FindByIdAsync(predicate, includes);
            if (pozo is null) throw PozoNotFound(id);

            return pozo.ToDto();
        }

        private NotFoundCoreException PozoNotFound(int id)
        {
            return new NotFoundCoreException("Pozo no encontrado para el id: " + id);
        }
    }
}
