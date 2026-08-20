using Electrobombas.Application.Dtos.TablaComunes;

namespace Electrobombas.Application.Services
{
    public interface ITablaComunService
    {
        Task<IReadOnlyList<TablaComunDto>> FindAllByIdsAsync(TablaComunFilterDto filter);
    }
}
