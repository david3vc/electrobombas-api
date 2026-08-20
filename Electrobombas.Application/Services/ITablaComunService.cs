using Electrobombas.Application.Dtos.TablaComunes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Services
{
    public interface ITablaComunService
    {
        Task<IReadOnlyList<TablaComunDto>> FindAllByIdsAsync(TablaComunFilterDto filter);
    }
}
