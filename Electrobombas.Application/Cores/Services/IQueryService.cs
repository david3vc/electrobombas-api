using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Cores.Services
{
    public interface IQueryService<TDto, ID>
    {
        Task<IReadOnlyList<TDto>> FindAllAsync();
        Task<TDto> FindByIdAsync(ID id);
    }
}
