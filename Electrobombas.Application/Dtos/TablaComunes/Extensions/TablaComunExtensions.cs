using Electrobombas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Dtos.TablaComunes.Extensions
{
    public static class TablaComunExtensions
    {
        extension(TablaComun tablaComun)
        {
            public TablaComunDto ToDto() => new()
            {
                Id = tablaComun.Id,
                IdFila = tablaComun.IdFila,
                IdTabla = tablaComun.IdTabla,
                Codigo = tablaComun.Codigo,
                Descripcion = tablaComun.Descripcion
            };
        }

        extension(IEnumerable<TablaComun> tablaComunes)
        {
            public List<TablaComunDto> ToDtoList() => tablaComunes.Select(t => t.ToDto()).ToList();
        }
    }
}
