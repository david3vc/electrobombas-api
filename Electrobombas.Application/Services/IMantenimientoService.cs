using Electrobombas.Application.Cores.Services;
using Electrobombas.Application.Dtos.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Services
{
    public interface IMantenimientoService : ICrudService<MantenimientoDto, MantenimientoSaveDto, int>, IPageService<MantenimientoDto, MantenimientoFilterDto>
    {
    }
}
