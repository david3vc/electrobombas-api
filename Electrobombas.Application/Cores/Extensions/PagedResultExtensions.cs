using Electrobombas.Application.Cores.Dtos;
using Electrobombas.Domain.Cores.Models;

namespace Electrobombas.Application.Cores.Extensions
{
    public static class PagedResultExtensions
    {
        extension<T, TDto>(PagedResult<T> pagedResult)
        {
            public PageResponse<TDto> ToPageResponse(Func<T, TDto> mapItem) => new()
            {
                Data = pagedResult.Data.Select(mapItem).ToList(),
                From = pagedResult.From,
                To = pagedResult.To,
                PerPage = pagedResult.PerPage,
                CurrentPage = pagedResult.CurrentPage,
                LastPage = pagedResult.LastPage,
                Total = pagedResult.Total,
            };
        }
    }
}
