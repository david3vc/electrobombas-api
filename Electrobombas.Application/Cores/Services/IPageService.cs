using Electrobombas.Application.Cores.Dtos;

namespace Electrobombas.Application.Cores.Services
{
    public interface IPageService<TDto, TDtoFilter>
    {
        Task<PageResponse<TDto>> FindAllPaginatedAsync(PageRequest<TDtoFilter> request);
    }
}
