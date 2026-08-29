using Electrobombas.Application.Cores.Services;
using Electrobombas.Application.Dtos.CambioEquipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Services
{
    public interface ICambioEquipoService : ICrudService<CambioEquipoDto, CambioEquipoSaveDto, int>
    {
    }
}
