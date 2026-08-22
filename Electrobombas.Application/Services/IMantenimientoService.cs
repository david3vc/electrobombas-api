using Electrobombas.Application.Cores.Services;
using Electrobombas.Application.Dtos.Mantenimientos;

namespace Electrobombas.Application.Services
{
    public interface IMantenimientoService : ICrudService<MantenimientoDto, MantenimientoSaveDto, int>, IPageService<MantenimientoDto, MantenimientoFilterDto>
    {
    }
}
