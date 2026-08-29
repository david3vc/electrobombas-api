using Electrobombas.Application.Cores.Services;
using Electrobombas.Application.Dtos.MedicionMantenimientos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Services
{
    public interface IMedicionMantenimientoService : ICrudService<MedicionMantenimientoDto, MedicionMantenimientoSaveDto, int>
    {
    }
}
