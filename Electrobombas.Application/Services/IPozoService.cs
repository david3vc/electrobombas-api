using Electrobombas.Application.Cores.Services;
using Electrobombas.Application.Dtos.Pozos;

namespace Electrobombas.Application.Services
{
    public interface IPozoService : ICrudService<PozoDto, PozoSaveDto, int>, IPageService<PozoDto, PozoFilterDto>
    {
    }
}
