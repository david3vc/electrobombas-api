//using AutoMapper;
using Electrobombas.Application.Dtos.TablaComunes;
using Electrobombas.Application.Dtos.TablaComunes.Extensions;
using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Electrobombas.Application.Services.Implementations
{
    public class TablaComunService : ITablaComunService
    {
        private readonly ITablaComunRepository _tablaComunRepository;

        public TablaComunService(ITablaComunRepository tablaComunRepository)
        {
            _tablaComunRepository = tablaComunRepository;
        }

        public async Task<IReadOnlyList<TablaComunDto>> FindAllByIdsAsync(TablaComunFilterDto filter)
        {
            Expression<Func<TablaComun, bool>> predicate = x =>
                (!filter.IdTabla.HasValue || x.IdTabla == filter.IdTabla)
                && (string.IsNullOrWhiteSpace(filter.Codigo) || x.Codigo.ToUpper().Contains(filter.Codigo.ToUpper()))
                && (x.IdFila != 0);

            IReadOnlyList<TablaComun> response = await _tablaComunRepository.FindAllAsync(predicate: predicate);

            return response.ToDtoList();
        }
    }
}
