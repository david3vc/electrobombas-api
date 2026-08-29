using Electrobombas.Application.Cores.Exceptions;
using Electrobombas.Application.Dtos.MedicionMantenimientos;
using Electrobombas.Application.Dtos.MedicionMantenimientos.Extensions;
using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;

namespace Electrobombas.Application.Services.Implementations
{
    public class MedicionMantenimientoService : IMedicionMantenimientoService
    {
        private readonly IMedicionMantenimientoRepository _medicionMantenimientoRepository;
        public MedicionMantenimientoService(IMedicionMantenimientoRepository medicionMantenimientoRepository)
        {
            _medicionMantenimientoRepository = medicionMantenimientoRepository;
        }

        public async Task<MedicionMantenimientoDto> CreateAsync(MedicionMantenimientoSaveDto saveDto)
        {
            MedicionMantenimiento medicionMantenimiento = saveDto.ToEntidad();
            medicionMantenimiento.FechaCreacion = DateTime.UtcNow;
            medicionMantenimiento.Estado = true;

            await _medicionMantenimientoRepository.SaveAsync(medicionMantenimiento);
            return medicionMantenimiento.ToDto();
        }

        public async Task<MedicionMantenimientoDto> DisabledAsync(int id)
        {
            MedicionMantenimiento? medicionMantenimiento = await _medicionMantenimientoRepository.FindByIdAsync(id);
            if (medicionMantenimiento is null) throw MedicionMantenimientoNotFound(id);

            medicionMantenimiento.Estado = !medicionMantenimiento.Estado;

            await _medicionMantenimientoRepository.SaveAsync(medicionMantenimiento);
            return medicionMantenimiento.ToDto();
        }

        public async Task<MedicionMantenimientoDto> EditAsync(int id, MedicionMantenimientoSaveDto saveDto)
        {
            MedicionMantenimiento? medicionMantenimiento = await _medicionMantenimientoRepository.FindByIdAsync(id);
            if (medicionMantenimiento is null) throw MedicionMantenimientoNotFound(id);

            medicionMantenimiento.ApplyFrom(saveDto);
            medicionMantenimiento.FechaActualizacion = DateTime.UtcNow;

            await _medicionMantenimientoRepository.SaveAsync(medicionMantenimiento);
            return medicionMantenimiento.ToDto();
        }

        public async Task<IReadOnlyList<MedicionMantenimientoDto>> FindAllAsync()
        {
            IReadOnlyList<MedicionMantenimiento> medicionMantenimientos = await _medicionMantenimientoRepository.FindAllAsync();

            return medicionMantenimientos.ToDtoList();
        }

        public async Task<MedicionMantenimientoDto> FindByIdAsync(int id)
        {
            MedicionMantenimiento? medicionMantenimiento = await _medicionMantenimientoRepository.FindByIdAsync(id);
            if (medicionMantenimiento is null) throw MedicionMantenimientoNotFound(id);

            return medicionMantenimiento.ToDto();
        }

        private NotFoundCoreException MedicionMantenimientoNotFound(int id)
        {
            return new NotFoundCoreException("Medicion Mantenimiento no encontrado para el id: " + id);
        }
    }
}
