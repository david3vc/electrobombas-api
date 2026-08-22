using Electrobombas.Application.Cores.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Cores.Services
{
    public interface IPageService<TDto, TDtoFilter>
    {
        Task<PageResponse<TDto>> FindAllPaginatedAsync(PageRequest<TDtoFilter> request);
    }
}
